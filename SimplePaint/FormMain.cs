using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SimplePaint
{
    public partial class FormMain : Form
    {
        /* default settins */
        private const int DEFAULT_PEN_WIDTH = 5;
        private readonly Color DEFAULT_PEN_COLOR = Color.Black;
        private readonly Color DEFAULT_BACK_COLOR = Color.White;
        private readonly (DashStyle, int) DEFAULT_LINE_STYLE = (DashStyle.Solid, 0);
        private readonly (SmoothingMode, bool) DEFAULT_SMOOTHING_ON = (SmoothingMode.AntiAlias, true);

        /* features pending */
        /*
        TODO highlight the selected shape
        TODO display grid and snap cursor position while drawing
        TODO some tool to resize and rotate the selected shape
        TODO tool to draw curves by points (Bezier etc.)
        TODO shape intersections
        TODO objects Z-axis ordering
        TODO load background image, crop and rotate it      
        TODO serialize shapes to save the drawing as an editable vector set
        */

        /* errors: */
        /*
        TODO center canvas unexpected behaviour - it actually centers on the second click sometimes
        */

        private IDrawing currentDrawing;

        public FormMain()
        {
            InitializeComponent();
            var dstyles = DashStyles.GetReadableNames();
            foreach (string style in dstyles)
            {
                _ = comboBoxStyle.Items.Add(style);
            }
            DrawToolBox.SetCanvas(drawCanvas1);
            ResetDrawingTools();
            ControlsActivation(false);
        }

        private void ControlsActivation(bool setEnabled)
        {
            //disable controls when no drawing opened or created; enable otherwise
            drawCanvas1.Visible = setEnabled;
            panelColors.Enabled = setEnabled;
            containerHScroll.Enabled = setEnabled;
            containerVScroll.Enabled = setEnabled;
            foreach (ToolStripItem tsitem in toolStripTools.Items)
            {
                if (tsitem is ToolStripButton)
                {
                    (tsitem as ToolStripButton).Enabled = setEnabled;
                }
            }
            foreach (ToolStripItem tsitem in statusStrip1.Items)
            {
                if (tsitem is ToolStripStatusLabel)
                {
                    (tsitem as ToolStripStatusLabel).Text = string.Empty;
                }
            }
            if (setEnabled)
            {
                toolStripButtonMove.PerformClick();
            }
            toolStripButtonNew.Enabled = true;
            toolStripButtonOpen.Enabled = true;
        }

        private void ResetDrawingTools()
        {
            //reset all drawing tools and corresponding controls to their defaults
            DrawToolBox.Select(DrawingTools.None);
            statusLabelTool.Text = string.Empty;
            foreach (ToolStripItem tsitem in toolStripTools.Items)
            {
                if (tsitem is ToolStripButton && (tsitem as ToolStripButton).CheckOnClick)
                {
                    (tsitem as ToolStripButton).Checked = false;
                }
            }

            DrawToolBox.CurrentPalette.ForegroundPen.Color = DEFAULT_PEN_COLOR;
            DrawToolBox.CurrentPalette.ForegroundPen.Width = DEFAULT_PEN_WIDTH;
            DrawToolBox.CurrentPalette.ForegroundPen.DashStyle = DEFAULT_LINE_STYLE.Item1;
            DrawToolBox.CurrentPalette.BackgroundPen.Color = DEFAULT_BACK_COLOR;
            DrawToolBox.CurrentPalette.BackgroundPen.Width = DEFAULT_PEN_WIDTH;
            DrawToolBox.CurrentPalette.BackgroundPen.DashStyle = DEFAULT_LINE_STYLE.Item1;
            pictureBoxToolColor.BackColor = DEFAULT_PEN_COLOR;
            pictureBoxBackColor.BackColor = DEFAULT_BACK_COLOR;
            trackBarWidth.Value = DEFAULT_PEN_WIDTH;
            comboBoxStyle.SelectedIndex = DEFAULT_LINE_STYLE.Item2;
            drawCanvas1.Smoothing = DEFAULT_SMOOTHING_ON.Item1;
            checkBoxSmoothing.Checked = DEFAULT_SMOOTHING_ON.Item2;

            drawCanvas1.Invalidate();
        }

        private void CurrentDrawing_Updated(Rectangle updatedBounds)
        {
            //TODO update only the changed region

            //private const int REDRAW_REGION_INFLATE = 5;
            //private const int SCROLL_MARGIN_ADD = 20;
            //increase update rectangle by REDRAW_REGION_INFLATE px each direction
            /*int offset = REDRAW_REGION_INFLATE * -1;
            int inflate = (int)(REDRAW_REGION_INFLATE * 2 * drawCanvas1.CanvasZoomFactor);
            Rectangle region = updatedBounds;
            region.Inflate(inflate, inflate);
            region.Offset(offset, offset);
            drawCanvas1.Invalidate(region);*/
            drawCanvas1.Invalidate();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButtonUndo_Click(object sender, EventArgs e)
        {
            currentDrawing?.Undo();
        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {
            currentDrawing?.Redo();
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            currentDrawing?.UndoAll();
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            drawCanvas1.ZoomIn();
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            drawCanvas1.ZoomOut();
        }

        private void buttonZoomReset_Click(object sender, EventArgs e)
        {
            drawCanvas1.ZoomReset();
            CenterCanvasInContainer();
        }

        private void toolStripButtonToolSelect_CheckedChanged(object sender, EventArgs e)
        {
            //make tool selection buttons behave as RadioButton (if one is on = others are off);
            //select proper tool in DrawToolBox when a button is checked;
            //write Tag string of the checked button to the status bar

            ToolStripButton btnSender = sender as ToolStripButton;
            ToolStrip tstrip = btnSender.Owner as ToolStrip;
            if (btnSender is null || tstrip is null)
            {
                return;
            }
            if (btnSender.Checked)
            {
                foreach (ToolStripItem tsitem in tstrip.Items)
                {
                    if (tsitem is ToolStripButton)
                    {
                        if ((tsitem as ToolStripButton).CheckOnClick && tsitem != btnSender)
                        {
                            (tsitem as ToolStripButton).Checked = false;
                        }
                    }
                }
                if (btnSender.Tag != null)
                {
                    statusLabelTool.Text = "Инструмент: " + btnSender.Tag.ToString();
                }
                if (btnSender == toolStripButtonHand)
                {
                    DrawToolBox.Select(DrawingTools.Selector);
                    return;
                }
                else if (btnSender == toolStripButtonMove)
                {
                    DrawToolBox.Select(DrawingTools.Move);
                    return;
                }
                else if (btnSender == toolStripButtonPencil)
                {
                    DrawToolBox.Select(DrawingTools.Pencil);
                    return;
                }
                else if (btnSender == toolStripButtonFreehand)
                {
                    DrawToolBox.Select(DrawingTools.Freehand);
                    return;
                }
                else if (btnSender == toolStripButtonRectangle)
                {
                    DrawToolBox.Select(DrawingTools.Rectangle);
                    return;
                }
                else if (btnSender == toolStripButtonEllipse)
                {
                    DrawToolBox.Select(DrawingTools.Ellipse);
                    return;
                }
                else if (btnSender == toolStripButtonEraser)
                {
                    DrawToolBox.Select(DrawingTools.Eraser);
                    return;
                }
                else if (btnSender == toolStripButtonFill)
                {
                    DrawToolBox.Select(DrawingTools.Fill);
                    return;
                }
                else
                {
                    //other button
                    DrawToolBox.Select(DrawingTools.None);
                    statusLabelTool.Text = string.Empty;
                    return;
                }
            }
            else
            {
                //unchecked button
                DrawToolBox.Select(DrawingTools.None);
                statusLabelTool.Text = string.Empty;
            }
        }

        private void pictureBoxToolColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pictureBoxToolColor.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;
                pictureBoxToolColor.BackColor = selectedColor;
                DrawToolBox.CurrentPalette.ForegroundPen.Color = selectedColor;
            }
        }

        private void pictureBoxBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pictureBoxBackColor.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;
                pictureBoxBackColor.BackColor = selectedColor;
                drawCanvas1.BackColor = selectedColor;
                DrawToolBox.CurrentPalette.BackgroundPen.Color = selectedColor;
            }
        }

        private void pictureBoxFillColor_Click(object sender, EventArgs e)
        {
            if (checkBoxNoFill.Checked)
            {
                return;
            }
            colorDialog1.Color = pictureBoxBackColor.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;
                pictureBoxFillColor.BackColor = selectedColor;
                DrawToolBox.CurrentPalette.FillBrush = new SolidBrush(selectedColor);
            }
        }

        private void checkBoxFill_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNoFill.Checked)
            {
                pictureBoxFillColor.BackColor = SystemColors.Control;
                DrawToolBox.CurrentPalette.FillBrush = null;
            }
            else
            {
                pictureBoxFillColor.BackColor = pictureBoxToolColor.BackColor;
                DrawToolBox.CurrentPalette.FillBrush = new SolidBrush(pictureBoxFillColor.BackColor);
            }
        }

        private void trackBarWidth_ValueChanged(object sender, EventArgs e)
        {
            labelThicknessValue.Text = trackBarWidth.Value.ToString() + " px";
            DrawToolBox.CurrentPalette.ForegroundPen.Width = trackBarWidth.Value;
            DrawToolBox.CurrentPalette.BackgroundPen.Width = trackBarWidth.Value;
        }

        private void comboBoxStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            var dstyle = DashStyles.GetDashStyleByName(comboBoxStyle.SelectedItem.ToString());
            DrawToolBox.CurrentPalette.ForegroundPen.DashStyle = dstyle;
            DrawToolBox.CurrentPalette.BackgroundPen.DashStyle = dstyle;
        }

        private void checkBoxSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            SmoothingMode prevMode = drawCanvas1.Smoothing;
            if (checkBoxSmoothing.Checked)
            {
                drawCanvas1.Smoothing = SmoothingMode.AntiAlias;
            }
            else
            {
                drawCanvas1.Smoothing = SmoothingMode.None;
            }
            if (drawCanvas1.Smoothing != prevMode)
            {
                drawCanvas1.Invalidate();
            }
        }

        private void drawCanvas1_SizeChanged(object sender, EventArgs e)
        {
            ScrollInit();
        }

        private void panelContainer_SizeChanged(object sender, EventArgs e)
        {
            ScrollInit();
        }

        private void ScrollInit()
        {
            containerVScroll.Minimum = -1 * drawCanvas1.Height;
            containerVScroll.Maximum = panelContainer.ClientSize.Height;

            containerHScroll.Minimum = -1 * drawCanvas1.Width;
            containerHScroll.Maximum = panelContainer.ClientSize.Width;

            CenterCanvasInContainer();
        }

        private void CenterCanvasInContainer()
        {
            //TODO срабатывает со второго раза если drawCanvas1.Size > panelContainer.Size

            int locY = (panelContainer.ClientSize.Height - drawCanvas1.Height - containerHScroll.Height) / 2;
            int locX = (panelContainer.ClientSize.Width - drawCanvas1.Width - containerVScroll.Width) / 2;
            containerVScroll.Value = locY;
            containerHScroll.Value = locX;
            drawCanvas1.Location = new Point(locX, locY);
        }

        private void containerVScroll_ValueChanged(object sender, EventArgs e)
        {
            if (drawCanvas1.Location.Y== containerVScroll.Value)
            {
                return;
            }
            Point canvasLocation = drawCanvas1.Location;
            canvasLocation.Y = containerVScroll.Value;
            drawCanvas1.Location = canvasLocation;
        }

        private void containerHScroll_ValueChanged(object sender, EventArgs e)
        {
            if (drawCanvas1.Location.X == containerHScroll.Value)
            {
                return;
            }
            Point canvasLocation = drawCanvas1.Location;
            canvasLocation.X = containerHScroll.Value;
            drawCanvas1.Location = canvasLocation;
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            bool changesDetected = DetectChangesAndSave();
            DialogNew dialogNew = new DialogNew();
            dialogNew.StartPosition = FormStartPosition.CenterParent;
            bool resultOK = dialogNew.ShowDialog(this) == DialogResult.OK;
            if (resultOK)
            {
                ResetDrawingTools();
                currentDrawing = new Drawing();
                currentDrawing.Updated += CurrentDrawing_Updated;
                currentDrawing.Size = dialogNew.SelectedDimensions;
                drawCanvas1.ZoomReset();
                drawCanvas1.SetSize(currentDrawing.Size);
                CenterCanvasInContainer();
                DrawToolBox.SetDrawing(currentDrawing);
            }
            ControlsActivation(resultOK || changesDetected);
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            bool changesDetected = DetectChangesAndSave();
            bool resultOK = openFileDialog1.ShowDialog(this) == DialogResult.OK;
            if (resultOK)
            {
                try
                {
                    Bitmap btmp = new Bitmap(openFileDialog1.FileName);
                    ResetDrawingTools();
                    currentDrawing = new Drawing();
                    currentDrawing.Updated += CurrentDrawing_Updated;
                    currentDrawing.AddBitmap(btmp, true);
                    drawCanvas1.ZoomReset();
                    drawCanvas1.SetSize(currentDrawing.Size);
                    CenterCanvasInContainer();
                    DrawToolBox.SetDrawing(currentDrawing);
                    resultOK = true;
                }
                catch
                {
                    _ = MessageBox.Show("Не удалось открыть файл!", "Ошибка открытия", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resultOK = false;
                }
            }
            ControlsActivation(resultOK || changesDetected);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveCurrentDrawing();
        }

        private bool DetectChangesAndSave()
        {
            bool changesDetected = (currentDrawing?.DrawingChanged).GetValueOrDefault();
            if (changesDetected)
            {
                DialogResult result = MessageBox.Show(this, "Имеются несохранённые изменения! Сохранить?", "Возможна потеря данных", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    SaveCurrentDrawing();
                }
            }
            return changesDetected;
        }

        private void SaveCurrentDrawing()
        {
            if (currentDrawing is null)
            {
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        drawCanvas1.GetBitmap().Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                        break;
                    case 2:
                        drawCanvas1.GetBitmap().Save(saveFileDialog1.FileName, ImageFormat.Png);
                        break;
                    case 3:
                        drawCanvas1.GetBitmap().Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                        break;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _ = new DialogAbout().ShowDialog(this);
        }

        private void drawCanvas1_OnMouseDownScaled(object sender, MouseEventArgs e)
        {
            DrawToolBox.ProcessMouseDown(e);
        }

        private void drawCanvas1_OnMouseMoveScaled(object sender, MouseEventArgs e)
        {
            DrawToolBox.ProcessMouseMove(e);
            statusLabelPosition.Text = e.X.ToString() + "; " + e.Y.ToString();
        }

        private void drawCanvas1_OnMouseUpScaled(object sender, MouseEventArgs e)
        {
            DrawToolBox.ProcessMouseUp(e);
        }

        private void drawCanvas1_ShapesDrawRequest(object sender, PaintEventArgs e)
        {
            currentDrawing?.DrawAll(e.Graphics);
            statusLabelScale.Text = "Масштаб " + Math.Round(drawCanvas1.ZoomFactor * 100) + "%";
        }

        private void drawCanvas1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Shift)
            {
                currentDrawing.DiscardSelectedShape();
            }
        }
    }
}
