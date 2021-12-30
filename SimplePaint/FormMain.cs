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
        //TODO load background image, crop and rotate
        //TODO display grid and snap cursor position while drawing
        //TODO fill shape tool
        //TODO freehand curve, rectangle (Shift+square), ellipse (Shift+circle) drawing tool
        //TODO pencil tool with shift makes straight lines
        //TODO selector tool to move, resize and delete drawn shapes
        //TODO shape intersections
        //TODO objects Z-axis

        /*
         * неадекватная работа прокрутки
         * неадекватное перемещение формы при уменьшении в 0,5 раз и меньше
         */

        private IDrawing currentDrawing;

        private DrawingTools currentTool;
        private Pen currentPen;
        private Point startPt;

        private enum DrawingTools
        {
            None,
            Hand,
            Pencil,
            Freehand,
            Rectangle,
            Ellipse,
            Eraser
        }

        public FormMain()
        {
            InitializeComponent();
            var dstyles = DashStyles.GetReadableNames();
            foreach (string style in dstyles)
            {
                _ = comboBoxStyle.Items.Add(style);
            }
            ResetDrawingTools();
            ControlsActivation(false);
        }

        private void ControlsActivation(bool setEnabled)
        {
            //disable controls when no drawing opened or created; enable otherwise
            drawCanvas1.Visible = setEnabled;
            panelColors.Enabled = setEnabled;
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
            toolStripButtonNew.Enabled = true;
            toolStripButtonOpen.Enabled = true;
        }

        private void ResetDrawingTools()
        {
            //reset all drawing tools to their defaults
            currentTool = DrawingTools.None;
            currentPen = new Pen(Color.Black, 1);
            currentPen.DashStyle = DashStyle.Solid;
            startPt = new Point(0, 0);
            drawCanvas1.CanvasSmoothing = SmoothingMode.None;

            pictureBoxToolColor.BackColor = Color.Black;
            pictureBoxBackColor.BackColor = Color.White;
            trackBarWidth.Value = 1;
            comboBoxStyle.SelectedIndex = 0;
            checkBoxSmoothing.Checked = false;
            drawCanvas1.Invalidate();
        }

        private void CurrentDrawing_Updated()
        {
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
        }

        private void toolStripButtonToolSelect_CheckedChanged(object sender, EventArgs e)
        {
            //make tool selection buttons behave as RadioButton (if one on = others off)
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
                statusLabelTool.Text = "Инструмент: " + btnSender.Tag.ToString();
                if (btnSender == toolStripButtonPencil)
                {
                    currentTool = DrawingTools.Pencil;
                    return;
                }
                else if (btnSender == toolStripButtonFreehand)
                {
                    currentTool = DrawingTools.Freehand;
                    return;
                }
                else if (btnSender == toolStripButtonHand)
                {
                    currentTool = DrawingTools.Hand;
                    return;
                }
                else if (btnSender == toolStripButtonEraser)
                {
                    currentTool = DrawingTools.Eraser;
                    return;
                }
                else if (btnSender == toolStripButtonRectangle)
                {
                    currentTool = DrawingTools.Rectangle;
                    return;
                }
                else if (btnSender == toolStripButtonEllipse)
                {
                    currentTool = DrawingTools.Ellipse;
                    return;
                }
                else
                {
                    currentTool = DrawingTools.None;
                    statusLabelTool.Text = string.Empty;
                    return;
                }
            }
            else
            {
                currentTool = DrawingTools.None;
                statusLabelTool.Text = string.Empty;
            }
        }

        private void pictureBoxToolColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pictureBoxToolColor.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;
                currentPen.Color = selectedColor;
                pictureBoxToolColor.BackColor = selectedColor;
            }
        }

        private void pictureBoxBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pictureBoxBackColor.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;
                drawCanvas1.BackColor = selectedColor;
                pictureBoxBackColor.BackColor = selectedColor;
            }
        }

        private void trackBarWidth_ValueChanged(object sender, EventArgs e)
        {
            labelThicknessValue.Text = trackBarWidth.Value.ToString() + " px";
            if (currentPen is null)
            {
                return;
            }
            currentPen.Width = trackBarWidth.Value;
        }

        private void comboBoxStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (currentPen is null)
            {
                return;
            }
            currentPen.DashStyle = DashStyles.GetDashStyleByName(comboBoxStyle.SelectedItem.ToString());
        }

        private void checkBoxSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            SmoothingMode prevMode = drawCanvas1.CanvasSmoothing;
            if (checkBoxSmoothing.Checked)
            {
                drawCanvas1.CanvasSmoothing = SmoothingMode.AntiAlias;
            }
            else
            {
                drawCanvas1.CanvasSmoothing = SmoothingMode.None;
            }
            if (drawCanvas1.CanvasSmoothing != prevMode)
            {
                drawCanvas1.Invalidate();
            }
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
                drawCanvas1.canvasSizeOriginal = currentDrawing.Size;
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
                    drawCanvas1.canvasSizeOriginal = currentDrawing.Size;
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
            new Form1().Show();
        }

        private void drawCanvas1_OnMouseDownScaled(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            startPt = e.Location;
            Cursor.Clip = new Rectangle(drawCanvas1.PointToScreen(Point.Empty), drawCanvas1.Size);
            Cursor.Current = Cursors.Cross;
            switch (currentTool)
            {
                case DrawingTools.Hand:
                    Cursor.Current = Cursors.SizeAll;
                    Cursor.Clip = new Rectangle(panelContainer.PointToScreen(Point.Empty), panelContainer.Size);
                    break;
                case DrawingTools.Pencil:
                    ShapesFactory.Init<Line>(currentPen, e.Location);
                    break;
                case DrawingTools.Freehand:
                    ShapesFactory.Init<Freepath>(currentPen, e.Location);
                    break;
                case DrawingTools.Eraser:
                    Pen eraserPen = (Pen)currentPen.Clone();
                    eraserPen.Color = pictureBoxBackColor.BackColor;
                    ShapesFactory.Init<Freepath>(eraserPen, e.Location);
                    break;
                case DrawingTools.Rectangle:
                    ShapesFactory.Init<Rectngl>(currentPen, e.Location);
                    break;
                case DrawingTools.Ellipse:
                    ShapesFactory.Init<Ellipse>(currentPen, e.Location);
                    break;
                default:
                    return;
            }
        }

        private void drawCanvas1_OnMouseMoveScaled(object sender, MouseEventArgs e)
        {
            statusLabelPosition.Text = e.X.ToString() + "; " + e.Y.ToString();
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (currentTool == DrawingTools.None)
            {
                return;
            }
            if (currentTool == DrawingTools.Hand)
            {
                //move canvas
                if (drawCanvas1.Width <= panelContainer.Width && drawCanvas1.Height <= panelContainer.Height)
                {
                    panelContainer.AutoScroll = false;
                }
                else
                {
                    panelContainer.AutoScroll = true;
                }
                int diffX = startPt.X - e.X;
                int diffY = startPt.Y - e.Y;
                if (diffX < 0 && panelContainer.DisplayRectangle.Width >= drawCanvas1.Width + panelContainer.Width)
                {
                    diffX = 0;
                }
                if (diffY < 0 && panelContainer.DisplayRectangle.Height >= drawCanvas1.Height + panelContainer.Height)
                {
                    diffY = 0;
                }
                if (diffX == 0 && diffY == diffX)
                {
                    return;
                }

                Point canvasLocationNew = drawCanvas1.Location;
                canvasLocationNew.X -= diffX;
                canvasLocationNew.Y -= diffY;
                drawCanvas1.Location = canvasLocationNew;
                return;
            }
            (sender as Control).Refresh();
            Graphics gr = (sender as Control).CreateGraphics();
            gr.ScaleTransform(drawCanvas1.CanvasZoomFactor, drawCanvas1.CanvasZoomFactor);
            ShapesFactory.AddPoint(e.Location, ModifierKeys == Keys.Shift);
            ShapesFactory.Finish().Draw(gr);
        }

        private void drawCanvas1_OnMouseUpScaled(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Arrow;
            Cursor.Clip = Rectangle.Empty;
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (currentTool == DrawingTools.None || currentTool == DrawingTools.Hand)
            {
                return;
            }
            currentDrawing?.AddShape(ShapesFactory.Finish());
        }

        private void drawCanvas1_ShapesDrawRequest(object sender, PaintEventArgs e)
        {
            currentDrawing?.DrawAll(e.Graphics);
            statusLabelScale.Text = "Масштаб " + Math.Round(drawCanvas1.CanvasZoomFactor * 100) + "%";
        }
    }
}
