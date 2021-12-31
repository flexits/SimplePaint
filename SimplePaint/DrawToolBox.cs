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

    internal class Palette
    {
        public Palette()
        {
            ForegroundPen = new Pen(Color.Black, 1);
            BackgroundPen = new Pen(Color.White, 1);
            FillBrush = null;
        }
        public Pen ForegroundPen { get; set; }
        public Pen BackgroundPen { get; set; }
        public Brush FillBrush { get; set; }
    }

    internal static class DrawToolBox
    {
        private static IDrawingTool currentTool;
        private static Palette currentPalette;
        private static IDrawing currentDrawing;
        private static DrawCanvas currentCanvas;

        public static Palette CurrentPalette { get => currentPalette; set => currentPalette = value; }

        static DrawToolBox()
        {
            currentPalette = new Palette();
        }

        public static void SetDrawing(IDrawing drawing)
        {
            currentDrawing = drawing;
        }

        public static void SetCanvas(DrawCanvas canvas)
        {
            currentCanvas = canvas;
        }

        public static void Select(DrawingTools tool)
        {
            switch (tool)
            {
                case DrawingTools.None:
                    currentTool = null;
                    break;
                case DrawingTools.Pencil:
                    currentTool = new GenericTool<Line>(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Freehand:
                    currentTool = new GenericTool<Freepath>(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Rectangle:
                    currentTool = new GenericTool<Rectngl>(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Ellipse:
                    currentTool = new GenericTool<Ellipse>(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Eraser:
                    currentTool = new ToolEraser(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Move:
                    currentTool = new ToolCanvasMove(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Selector:
                case DrawingTools.Fill:
                    currentTool = null;
                    break;
            }
        }

        public static void ProcessMouseDown(MouseEventArgs e)
        {
            currentTool?.ProcessMouseDown(e);
        }

        public static void ProcessMouseMove(MouseEventArgs e)
        {
            currentTool?.ProcessMouseMove(e);
        }

        public static void ProcessMouseUp(MouseEventArgs e)
        {
            currentTool?.ProcessMouseUp(e);
        }
    }

    internal interface IDrawingTool
    {
        void ProcessMouseDown(MouseEventArgs e);
        void ProcessMouseMove(MouseEventArgs e);
        void ProcessMouseUp(MouseEventArgs e);
    }

    internal abstract class DrawingTool : IDrawingTool
    {
        private protected Palette palette;
        private protected DrawCanvas canvas;
        private protected IDrawing drawing;
        public DrawingTool(Palette palette, DrawCanvas canvas, IDrawing drawing)
        {
            this.palette = palette;
            this.canvas = canvas;
            this.drawing = drawing;
        }
        public abstract void ProcessMouseDown(MouseEventArgs e);
        public abstract void ProcessMouseMove(MouseEventArgs e);
        public abstract void ProcessMouseUp(MouseEventArgs e);
    }

    internal class GenericTool<T> : DrawingTool where T : Shape
    {
        public GenericTool(Palette palette, DrawCanvas canvas, IDrawing drawing) : base(palette, canvas, drawing) { }

        public override void ProcessMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (canvas is null)
            {
                throw new NullReferenceException();
            }
            Cursor.Current = Cursors.Cross;
            Cursor.Clip = new Rectangle(canvas.PointToScreen(Point.Empty), canvas.Size);
            ShapesFactory.Init<T>(palette.ForegroundPen, palette.FillBrush, e.Location);
        }

        public override void ProcessMouseMove(MouseEventArgs e)
        {
            if (canvas is null)
            {
                throw new NullReferenceException();
            }
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            canvas.Refresh();
            Graphics gr = canvas.CreateGraphics();
            gr.ScaleTransform(canvas.CanvasZoomFactor, canvas.CanvasZoomFactor);
            ShapesFactory.AddPoint(e.Location, Control.ModifierKeys == Keys.Shift);
            ShapesFactory.Finish().Draw(gr);
        }

        public override void ProcessMouseUp(MouseEventArgs e)
        {
            if (drawing is null)
            {
                throw new NullReferenceException();
            }
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            drawing?.AddShape(ShapesFactory.Finish());
            Cursor.Current = Cursors.Arrow;
            Cursor.Clip = Rectangle.Empty;
        }
    }

    internal class ToolEraser : GenericTool<Freepath>
    {
        public ToolEraser(Palette palette, DrawCanvas canvas, IDrawing drawing) : base(palette, canvas, drawing) { }
        public override void ProcessMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (canvas is null)
            {
                throw new NullReferenceException();
            }
            Cursor.Current = Cursors.Cross;
            Cursor.Clip = new Rectangle(canvas.PointToScreen(Point.Empty), canvas.Size);
            ShapesFactory.Init<Freepath>(palette.BackgroundPen, palette.FillBrush, e.Location);
        }
    }

    internal class ToolCanvasMove : DrawingTool
    {
        public ToolCanvasMove(Palette palette, DrawCanvas canvas, IDrawing drawing) : base(palette, canvas, drawing) { }

        private Point startPt;

        public override void ProcessMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (canvas is null)
            {
                throw new NullReferenceException();
            }
            startPt = e.Location;
            Cursor.Current = Cursors.SizeAll;
            Panel panelContainer = canvas.Parent as Panel;
            Cursor.Clip = new Rectangle(panelContainer.PointToScreen(Point.Empty), panelContainer.Size);
        }

        public override void ProcessMouseMove(MouseEventArgs e)
        {
            if (canvas is null)
            {
                throw new NullReferenceException();
            }
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            int diffX = startPt.X - e.X;
            int diffY = startPt.Y - e.Y;
            Point canvasLocationNew = canvas.Location;
            canvasLocationNew.X -= diffX;
            canvasLocationNew.Y -= diffY;
            canvas.Location = canvasLocationNew;
        }

        public override void ProcessMouseUp(MouseEventArgs e)
        {
            Cursor.Current = Cursors.Arrow;
            Cursor.Clip = Rectangle.Empty;
        }
    }
}
