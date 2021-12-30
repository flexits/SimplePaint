using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimplePaint
{
    internal enum DrawingTools
    {
        None,
        Selector,
        Move,
        Pencil,
        Freehand,
        Rectangle,
        Ellipse,
        Eraser,
        Fill
    }

    internal static class DrawToolBox
    {
        private static DrawingTools currentTool;
        private static Dictionary<DrawingTools, IDrawingTool> availableTools;
        private static Point mouseDownPt;

        public static Pen CurrentPen { get; set; }
        public static Pen EraserPen { get; set; }
        public static IDrawing CurrentDrawing { get; set; }

        static DrawToolBox()
        {
            ResetToolSelection();
            availableTools = new Dictionary<DrawingTools, IDrawingTool>
            {
                [DrawingTools.None] = null,
                [DrawingTools.Pencil] = new ToolPencil()
            };
        }

        public static void Select(DrawingTools tool)
        {
            currentTool = tool;
        }

        public static void ResetToolSelection()
        {
            currentTool = DrawingTools.None;
            CurrentPen = new Pen(Color.Black, 1)
            {
                DashStyle = DashStyle.Solid
            };
            EraserPen = new Pen(Color.Black, 1)
            {
                DashStyle = DashStyle.Solid
            };
            mouseDownPt = Point.Empty;
        }

        public static void ProcessMouseDown(DrawCanvas sender, MouseEventArgs e)
        {
            mouseDownPt = e.Location;
            availableTools[currentTool]?.ProcessMouseDown(CurrentPen, sender, e);
        }

        public static void ProcessMouseMove(DrawCanvas sender, MouseEventArgs e)
        {
            availableTools[currentTool]?.ProcessMouseMove(sender, e);
        }

        public static void ProcessMouseUp(DrawCanvas sender, MouseEventArgs e)
        {
            availableTools[currentTool]?.ProcessMouseUp(CurrentDrawing, sender, e);
        }
    }

    internal interface IDrawingTool
    {
        void ProcessMouseDown(Pen currentPen, DrawCanvas sender, MouseEventArgs e);
        void ProcessMouseMove(DrawCanvas sender, MouseEventArgs e);
        void ProcessMouseUp(IDrawing currentDrawing, DrawCanvas sender, MouseEventArgs e);
    }

    internal class ToolGeneric : IDrawingTool
    {
        public virtual void ProcessMouseDown(Pen currentPen, DrawCanvas sender, MouseEventArgs e) { }

        public void ProcessMouseMove(DrawCanvas sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            sender.Refresh();
            Graphics gr = sender.CreateGraphics();
            gr.ScaleTransform(sender.CanvasZoomFactor, sender.CanvasZoomFactor);
            ShapesFactory.AddPoint(e.Location, Control.ModifierKeys == Keys.Shift);
            ShapesFactory.Finish().Draw(gr);
        }

        public void ProcessMouseUp(IDrawing currentDrawing, DrawCanvas sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            currentDrawing?.AddShape(ShapesFactory.Finish());
        }
    }

    internal class ToolPencil : ToolGeneric
    {
        public override void ProcessMouseDown(Pen currentPen, DrawCanvas sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ShapesFactory.Init<Line>(currentPen, e.Location);
        }
    }

    internal class ToolFreehand : ToolGeneric
    {
        public override void ProcessMouseDown(Pen currentPen, DrawCanvas sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ShapesFactory.Init<Freepath>(currentPen, e.Location);
        }
    }

    internal class ToolRectangle : ToolGeneric
    {
        public override void ProcessMouseDown(Pen currentPen, DrawCanvas sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ShapesFactory.Init<Rectngl>(currentPen, e.Location);
        }
    }

    internal class ToolEllipse: ToolGeneric
    {
        public override void ProcessMouseDown(Pen currentPen, DrawCanvas sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ShapesFactory.Init<Ellipse>(currentPen, e.Location);
        }
    }

    internal class ToolEraser : ToolGeneric
    {
        public override void ProcessMouseDown(Pen currentPen, DrawCanvas sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ShapesFactory.Init<Freepath>(currentPen, e.Location);
        }
    }
}
