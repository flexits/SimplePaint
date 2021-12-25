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
        //TODO save and load
        //TODO scroll and zoom
        //TODO pen color and style
        //TODO freehand curve, rectangle, circle drawing tool
        //TODO pencil tool with shift makes straight lines
        //TODO eraser tool (right button) and shape deletion tool
        //TODO move and resize drawn shapes

        /*
         * Buttons: new, open, save, clear, undo, redo
         * Tools-drawing: pencil, freehand, rectangle, circle
         * Tools-erasing: eraser, delete shapes
         */
        public FormMain()
        {
            InitializeComponent();
            _ = typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelCanvas, new object[] { true });
            currentTool = DrawingTools.None;
            currentBrush = new SolidBrush(Color.Black);
            currentPen = new Pen(currentBrush);
            startPt = new Point(0, 0);
            //TODO set custom panelCanvas size and center it in panelContainer
            panelCanvas.Dock = DockStyle.Fill;
        }

        DrawingTools currentTool;
        Brush currentBrush;
        Pen currentPen;
        Point startPt;

        enum DrawingTools
        {
            None,
            Pencil,
        }

        Stack<IDrawable> shapes = new Stack<IDrawable>();
        Stack<IDrawable> discarded = new Stack<IDrawable>();

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

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (IDrawable shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            startPt = e.Location;
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            //TODO check if e.Location is within borders of panelContainer
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
            Graphics canvas = (sender as Control).CreateGraphics();
            (sender as Control).Refresh();
            switch (currentTool)
            {
                case DrawingTools.Pencil:
                    new Line(currentPen, startPt, e.Location).Draw(canvas);
                    break;
                default:
                    return;
            }
        }
    }
}
