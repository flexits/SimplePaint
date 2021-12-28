﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace SimplePaint
{
    public partial class FormMain : Form
    {
        private const float ZOOM_STEP = 0.1F;
        private const float ZOOM_DEFT = 1.0F;

        //TODO save and load file
        //TODO load background image, crop and rotate
        //TODO display grid and snap cursor position while drawing
        //TODO fill shape tool
        //TODO freehand curve, rectangle (Shift+square), ellipse (Shift+circle) drawing tool
        //TODO pencil tool with shift makes straight lines
        //TODO selector tool to move, resize and delete drawn shapes
        //TODO shape intersections
        //TODO objects Z-axis

        /*
         * Для лабы: 
         * сохранять и загружать растр +(скролл если не вмещается в экран);
         * левой рисовать, правой стирать (менять цвет на белый)
         + задавать цвет, толщину и стиль линии
         + undo и redo 
         */

        private IDrawing currentDrawing;

        private DrawingTools currentTool;
        private Pen currentPen;
        private Point startPt;

        private enum DrawingTools
        {
            None,
            Selector,
            Pencil,
            Freehand,
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
            ResetDrawing();
            ControlsActivation(false);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            toolStripButtonNew.PerformClick();
            drawCanvas1.CenterParent();
            toolStripButtonSelect.Checked = true;
        }

        private void ControlsActivation(bool setEnabled)
        {
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

        private void ResetDrawing()
        {
            currentDrawing = new Drawing();
            currentDrawing.Updated += CurrentDrawing_Updated;

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
            currentDrawing.Undo();
        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {
            currentDrawing.Redo();
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            currentDrawing.UndoAll();
        }

        private void toolStripButtonToolSelect_CheckedChanged(object sender, EventArgs e)
        {
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
                else if (btnSender == toolStripButtonSelect)
                {
                    currentTool = DrawingTools.Selector;
                    return;
                }
                else if (btnSender == toolStripButtonEraser)
                {
                    currentTool = DrawingTools.Eraser;
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

        private void panelContainer_Resize(object sender, EventArgs e)
        {
            drawCanvas1.CenterParent();
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
            if (currentDrawing.DrawingChanged)
            {
                SaveDrawing(true);
            }
            DialogNew dialogNew = new DialogNew();
            dialogNew.StartPosition = FormStartPosition.CenterParent;
            bool resultOK = dialogNew.ShowDialog(this) == DialogResult.OK;
            if (resultOK)
            {
                ResetDrawing();
                drawCanvas1.Size = dialogNew.SelectedDimensions;
                drawCanvas1.canvasSizeOriginal = dialogNew.SelectedDimensions;
                drawCanvas1.CenterParent();
                toolStripButtonSelect.Checked = true;
            }
            ControlsActivation(resultOK || currentDrawing.DrawingChanged);
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            if (currentDrawing.DrawingChanged)
            {
                SaveDrawing(true);
            }
            bool resultOK = openFileDialog1.ShowDialog(this) == DialogResult.OK;
            if (resultOK)
            {
                ResetDrawing();
                LoadFile();
                drawCanvas1.CenterParent();
                toolStripButtonSelect.Checked = true;
            }
            ControlsActivation(resultOK || currentDrawing.DrawingChanged);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveDrawing();
        }

        private void SaveDrawing(bool issuePrompt = false)
        {
            if (issuePrompt)
            {
                DialogResult result = MessageBox.Show(this, "Имеются несохранённые изменения! Сохранить?", "Возможна потеря данных", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result != DialogResult.OK)
                {
                    return;
                }
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                throw new NotImplementedException();
            }
        }

        private void LoadFile()
        {
            throw new NotImplementedException();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void drawCanvas1_OnMouseDownScaled(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            switch (currentTool)
            {
                case DrawingTools.Selector:
                    Cursor.Current = Cursors.SizeAll;
                    break;
                case DrawingTools.Pencil:
                    Cursor.Current = Cursors.Cross;
                    ShapesFactory.Init<Line>(currentPen, e.Location);
                    break;
                case DrawingTools.Freehand:
                    Cursor.Current = Cursors.Cross;
                    ShapesFactory.Init<Freepath>(currentPen, e.Location);
                    break;
                case DrawingTools.Eraser:
                    Cursor.Current = Cursors.Cross;
                    Pen eraserPen = (Pen)currentPen.Clone();
                    eraserPen.Color = pictureBoxBackColor.BackColor;
                    ShapesFactory.Init<Freepath>(eraserPen, e.Location);
                    break;
                default:
                    return;
            }
            startPt = drawCanvas1.Location;
        }

        private void drawCanvas1_OnMouseMoveScaled(object sender, MouseEventArgs e)
        {
            //TODO if cursor is out of bounds set label to 0;0
            statusLabelPosition.Text = e.X.ToString() + "; " + e.Y.ToString();
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (currentTool == DrawingTools.None)
            {
                return;
            }
            if (currentTool == DrawingTools.Selector)
            {
                //move canvas
                //не работает!
                int diffX = startPt.X - e.X;
                int diffY = startPt.Y - e.Y;
                Point canvasLocationNew = drawCanvas1.Location;
                canvasLocationNew.X -= diffX;
                canvasLocationNew.Y -= diffY;
                drawCanvas1.Location = canvasLocationNew;
                return;
            }
            //TODO check if e.Location is within the borders of panelContainer
            (sender as Control).Refresh();
            //неправильно! Draw должно быть UNSCALED (передать уже масшитабированный Graphics?)
            ShapesFactory.Finish(e.Location).Draw((sender as Control).CreateGraphics());
        }

        private void drawCanvas1_OnMouseUpScaled(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Arrow;
            //TODO check if e.Location is within the borders of panelCanvas
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (currentTool == DrawingTools.None || currentTool == DrawingTools.Selector)
            {
                return;
            }
            currentDrawing.AddShape(ShapesFactory.Finish(e.Location));
        }

        private void drawCanvas1_ShapesDrawRequest(object sender, PaintEventArgs e)
        {
            currentDrawing.DrawAll(e.Graphics);
            statusLabelScale.Text = "Масштаб " + Math.Round(drawCanvas1.CanvasZoomFactor * 100) + "%";
        }
    }
}
