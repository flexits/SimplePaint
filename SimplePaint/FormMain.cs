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
        //TODO zoom the canvas 
        //TODO fill shape tool
        //TODO freehand curve, rectangle (Shift+square), ellipse (Shift+circle) drawing tool
        //TODO pencil tool with shift makes straight lines
        //TODO selector tool to move, resize and delete drawn shapes
        //TODO shape intersections
        //TODO objects Z-axis

        /*
         * Для лабы: 
         * сохранять и загружать растр (скролл если не вмещается в экран);
         * левой рисовать, правой стирать (менять цвет на белый)
         + задавать цвет, толщину и стиль линии
         + undo и redo 
         */

        public FormMain()
        {
            InitializeComponent();
            _ = typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelCanvas, new object[] { true });

            var dstyles = DashStyles.GetReadableNames();
            foreach (string style in dstyles)
            {
                _ = comboBoxStyle.Items.Add(style);
            }
            comboBoxStyle.SelectedIndex = 0;

            currentTool = DrawingTools.None;
            currentPen = new Pen(Color.Black, 1);
            currentPen.DashStyle = DashStyle.Solid;
            startPt = new Point(0, 0);
            currentSmoothingMode = SmoothingMode.None;
            canvasZoomFactor = ZOOM_DEFT;
            //TODO set custom panelCanvas size and center it in panelContainer

            ControlsActivation(false);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            toolStripButtonNew.PerformClick();
            CenterCanvas();
            toolStripButtonSelect.PerformClick();
        }

        private DrawingTools currentTool;
        private Pen currentPen;
        private Point startPt;
        private SmoothingMode currentSmoothingMode;
        private float canvasZoomFactor;
        private Size canvasSizeOriginal;

        private enum DrawingTools
        {
            None,
            Selector,
            Pencil,
            Freehand
        }

        private Stack<IDrawable> shapes = new Stack<IDrawable>();
        private Stack<IDrawable> discarded = new Stack<IDrawable>();

        private void CenterCanvas()
        {
            if (!panelCanvas.Visible)
            {
                return;
            }
            Point canvasLocationNew = new Point(0, 0);
            int diffY = panelContainer.Height - panelCanvas.Height;
            if (diffY > 0)
            {
                canvasLocationNew.Y = diffY / 2;
            }
            int diffX = panelContainer.Width - panelCanvas.Width;
            if (diffX > 0)
            {
                canvasLocationNew.X = diffX / 2;
            }
            panelCanvas.Location = canvasLocationNew;
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButtonUndo_Click(object sender, EventArgs e)
        {
            if (shapes.Count == 0)
            {
                return;
            }
            discarded.Push(shapes.Pop());
            panelCanvas.Invalidate();
        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {
            if (discarded.Count == 0)
            {
                return;
            }
            shapes.Push(discarded.Pop());
            panelCanvas.Invalidate();
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            Stack<IDrawable> temp = new Stack<IDrawable>();
            while (shapes.Count > 0)
            {
                temp.Push(shapes.Pop());
            }
            while (temp.Count > 0)
            {
                discarded.Push(temp.Pop());
            }
            panelCanvas.Invalidate();
        }

        private void toolStripButtonSelect_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as ToolStripButton).Checked)
            {
                currentTool = DrawingTools.Selector;
            }
            else
            {
                currentTool = DrawingTools.None;
            }
        }

        private void toolStripButtonPencil_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as ToolStripButton).Checked)
            {
                currentTool = DrawingTools.Pencil;
            }
            else
            {
                currentTool = DrawingTools.None;
            }
        }

        private void toolStripButtonFreehand_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as ToolStripButton).Checked)
            {
                currentTool = DrawingTools.Freehand;
            }
            else
            {
                currentTool = DrawingTools.None;
            }
        }

        private void toolStripButtonToolSelect_MouseDown(object sender, MouseEventArgs e)
        {
            ToolStripButton btncurrent = sender as ToolStripButton;
            ToolStrip tstrip = btncurrent.Owner as ToolStrip;
            if (btncurrent is null || tstrip is null)
            {
                return;
            }
            foreach (ToolStripItem tsitem in tstrip.Items)
            {
                if (tsitem is ToolStripButton)
                {
                    if (tsitem != btncurrent)
                    {
                        (tsitem as ToolStripButton).Checked = false;
                    }
                }
            }
        }

        private void toolStripButtonToolSelect_Click(object sender, EventArgs e)
        {
            ToolStripButton btncurrent = sender as ToolStripButton;
            if (btncurrent.CheckState==CheckState.Checked)
            {
                statusLabelTool.Text = "Инструмент: " + btncurrent.Tag.ToString();
            }
            else
            {
                statusLabelTool.Text = string.Empty;
            }
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = currentSmoothingMode;
            e.Graphics.ScaleTransform(canvasZoomFactor, canvasZoomFactor);
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                shapes.ElementAt(i).Draw(e.Graphics);
            }
            Size zoomedSize = new Size((int)(canvasSizeOriginal.Width * canvasZoomFactor), (int)(canvasSizeOriginal.Height * canvasZoomFactor));
            panelCanvas.Size = zoomedSize;
            //TODO lines drawn on a zoomed canvas are out of bound. Need to change the zooming method
            statusLabelScale.Text = "Масштаб " + Math.Round(canvasZoomFactor * 100) + "%";
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            startPt = e.Location;
            switch (currentTool)
            {
                case DrawingTools.Selector:
                    Cursor.Current = Cursors.SizeAll;
                    break;
                case DrawingTools.Pencil:
                case DrawingTools.Freehand:
                    Cursor.Current = Cursors.Cross;
                    break;
                default:
                    return;
            }
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Arrow;
            //TODO check if e.Location is within the borders of panelCanvas
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (currentTool == DrawingTools.None)
            {
                return;
            }
            IDrawable currentShape;
            switch (currentTool)
            {
                case DrawingTools.Pencil:
                    currentShape = new Line((Pen)currentPen.Clone(), startPt, e.Location);
                    break;
                default:
                    return;
            }
            shapes.Push(currentShape);
            panelCanvas.Invalidate(currentShape.GetBoundingRectangle());
            discarded.Clear();
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
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
            //TODO check if e.Location is within the borders of panelContainer
            Graphics canvas = (sender as Control).CreateGraphics();
            (sender as Control).Refresh();
            switch (currentTool)
            {
                case DrawingTools.Selector:
                    int diffX = startPt.X - e.Location.X;
                    int diffY = startPt.Y - e.Location.Y;
                    Point canvasLocationNew = panelCanvas.Location;
                    canvasLocationNew.X -= diffX;
                    canvasLocationNew.Y -= diffY;
                    panelCanvas.Location = canvasLocationNew;
                    break;
                case DrawingTools.Pencil:
                    new Line(currentPen, startPt, e.Location).Draw(canvas);
                    break;
                default:
                    return;
            }
        }

        private void panelContainer_Resize(object sender, EventArgs e)
        {
            CenterCanvas();
        }

        private void panelCanvas_Resize(object sender, EventArgs e)
        {
            //TODO only if not moved by selector tool
            CenterCanvas();
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            canvasZoomFactor += ZOOM_STEP;
            panelCanvas.Invalidate();
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            if (canvasZoomFactor <= ZOOM_STEP)
            {
                return;
            }
            canvasZoomFactor -= ZOOM_STEP;
            panelCanvas.Invalidate();
        }

        private void buttonZoomReset_Click(object sender, EventArgs e)
        {
            canvasZoomFactor = ZOOM_DEFT;
            panelCanvas.Invalidate();
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
                panelCanvas.BackColor = selectedColor;
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
            SmoothingMode prevMode = currentSmoothingMode;
            if (checkBoxSmoothing.Checked)
            {
                currentSmoothingMode = SmoothingMode.AntiAlias;
            }
            else
            {
                currentSmoothingMode = SmoothingMode.None;
            }
            if (currentSmoothingMode != prevMode)
            {
                panelCanvas.Invalidate();
            }
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            DialogNew dialogNew = new DialogNew();
            dialogNew.StartPosition = FormStartPosition.CenterParent;
            bool resultOK = dialogNew.ShowDialog(this) == DialogResult.OK;
            if (resultOK)
            {
                canvasSizeOriginal = dialogNew.SelectedDimensions;
                panelCanvas.Width = canvasSizeOriginal.Width;
                panelCanvas.Height = canvasSizeOriginal.Height;
                panelCanvas.Visible = true;
            }
            ControlsActivation(resultOK);
        }

        private void ControlsActivation(bool setEnabled)
        {
            panelCanvas.Visible = setEnabled;
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
    }
}
