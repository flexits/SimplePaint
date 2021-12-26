using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        //TODO create new canvas with given size
        //TODO load background image, crop and rotate
        //TODO display grid and snap cursor position while drawing
        //TODO scroll and zoom the canvas
        //TODO cursor position indicator
        //TODO pen color and style, canvas color and texture
        //TODO fill shape tool
        //TODO freehand curve, rectangle (Shift+square), ellipse (Shift+circle) drawing tool
        //TODO pencil tool with shift makes straight lines
        //TODO selector tool to move, resize and delete drawn shapes
        //TODO shape intersections

        /*
         * Для лабы: 
         * сохранять и загружать растр (скролл если не вмещается в экран);
         * левой рисовать, правой стирать (менять цвет на белый)
         * задавать цвет, толщину и стиль линии
         * undo и redo в виде сохранения bitmap
         */

        public FormMain()
        {
            InitializeComponent();
            _ = typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelCanvas, new object[] { true });

            currentTool = DrawingTools.None;
            currentBrush = new SolidBrush(Color.Black);
            currentPen = new Pen(currentBrush);
            startPt = new Point(0, 0);
            canvasZoomFactor = ZOOM_DEFT;
            canvasSizeOriginal = panelCanvas.Size;
            //TODO set custom panelCanvas size and center it in panelContainer

            panelCanvas.Width = 200;
            panelCanvas.Height = 200;

            CenterCanvas();
            toolStripButtonSelect.PerformClick();
        }

        DrawingTools currentTool;
        Brush currentBrush;
        Pen currentPen;
        Point startPt;
        float canvasZoomFactor;
        Size canvasSizeOriginal;

        enum DrawingTools
        {
            None,
            Selector,
            Pencil,
            Freehand
        }

        Stack<IDrawable> shapes = new Stack<IDrawable>();
        Stack<IDrawable> discarded = new Stack<IDrawable>();

        private void CenterCanvas()
        {
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

        private void toolStripButton_MouseDown(object sender, MouseEventArgs e)
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

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(canvasZoomFactor, canvasZoomFactor);
            foreach (IDrawable shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
            Size zoomedSize = new Size((int)(canvasSizeOriginal.Width * canvasZoomFactor), (int)(canvasSizeOriginal.Height * canvasZoomFactor));
            panelCanvas.Size = zoomedSize;
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
                    currentShape = new Line(currentPen, startPt, e.Location);
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
    }
}
