using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimplePaint
{
    /*
     * The IDrawingTool class incapsulates mouse events processing methods in order to
     * create or modify drawing contents etc. and visualizes this process by altering 
     * the mouse cursor or painting a graphics outline of the object.
     * 
     * Constructor of the IDrawingTool class is provided with links to current
     * drawing area (DrawCanvas), current drawing object (IDrawing) and Palette object, 
     * incapsulating user-selected pens and brushes.
     *
     * © Alexander V. Korostelin, SibSUTIS, Novosibirsk 2021
     */

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

    internal enum DrawingTools      //available drawing tools
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

    internal partial class GenericTool<T> : DrawingTool where T : IDrawable { } //creates IDrawable object of type provided
    internal partial class ToolEraser : GenericTool<Freepath> { }               //eraser tool (it's actually a Freehand shape with Background colored pen)
    internal partial class ToolCanvasMove : DrawingTool { }                     //mouse drags drawing area with left button pressed
    internal partial class ToolShapeSelect : DrawingTool { }                    //select a shape and move selected on mouse move with left button pressed
    internal partial class ToolShapeFill : DrawingTool { }                      //select a shape and fill it with color

    internal partial class GenericTool<T> : DrawingTool where T : IDrawable     
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
            ShapesFactory.AddPoint(e.Location, Control.ModifierKeys == Keys.Shift);
            ShapesFactory.Finish().Draw(canvas.GetGraphics());
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

    internal partial class ToolEraser : GenericTool<Freepath>
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

    internal partial class ToolCanvasMove : DrawingTool
    {
        public ToolCanvasMove(Palette palette, DrawCanvas canvas, IDrawing drawing) : base(palette, canvas, drawing) { }

        private Point startPt;
        private Rectangle outline;

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
            startPt = PointMath.ScalePoint(e.Location, canvas.ZoomFactor);
            Cursor.Current = Cursors.NoMove2D;
            Cursor.Clip = new Rectangle(canvas.Parent.PointToScreen(Point.Empty), canvas.Parent.Size);
            outline = new Rectangle(canvas.Location, canvas.Size);
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
            Point cursorLocation = PointMath.ScalePoint(e.Location, canvas.ZoomFactor);
            int diffX = startPt.X - cursorLocation.X;
            int diffY = startPt.Y - cursorLocation.Y;
            Point newLocation = canvas.Location;
            newLocation.X -= diffX;
            newLocation.Y -= diffY;
            outline.Location = newLocation;
            canvas.Parent.Refresh();
            canvas.Parent.CreateGraphics().DrawRectangle(new Pen(Color.Red, 1) { DashStyle = DashStyle.DashDotDot }, outline);
        }

        public override void ProcessMouseUp(MouseEventArgs e)
        {
            Cursor.Current = Cursors.Arrow;
            Cursor.Clip = Rectangle.Empty;
            canvas.Parent.Refresh();
            canvas.Location = outline.Location;
        }
    }

    internal partial class ToolShapeSelect : DrawingTool
    {
        public ToolShapeSelect(Palette palette, DrawCanvas canvas, IDrawing drawing) : base(palette, canvas, drawing) { }

        private Point prevPt;
        private Point startPt;
        private IDrawable selectedShape;

        public override void ProcessMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            selectedShape = drawing.SelectShapeByPoint(e.Location);
            if (selectedShape is null)
            {
                return;
            }
            selectedShape = selectedShape.Clone() as IDrawable;
            Cursor.Current = Cursors.SizeAll;
            Cursor.Clip = new Rectangle(canvas.PointToScreen(Point.Empty), canvas.Size);
            startPt = prevPt = e.Location;
        }

        public override void ProcessMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (selectedShape is null || canvas is null)
            {
                return;
            }
            Point offset = PointMath.Subtract(e.Location, prevPt);
            selectedShape.Move(offset);
            prevPt = e.Location;

            canvas.Refresh();
            selectedShape.Draw(canvas.GetGraphics());
        }

        public override void ProcessMouseUp(MouseEventArgs e)
        {
            if (e.Location != startPt)
            {
                Point offset = PointMath.Subtract(e.Location, startPt);
                drawing.MoveSelectedShape(offset);
            }
            Cursor.Current = Cursors.Arrow;
            Cursor.Clip = Rectangle.Empty;
        }
    }

    internal partial class ToolShapeFill : DrawingTool
    {
        public ToolShapeFill(Palette palette, DrawCanvas canvas, IDrawing drawing) : base(palette, canvas, drawing) { }

        public override void ProcessMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (drawing.SelectShapeByPoint(e.Location, true) is null)
            {
                return;
            }
            drawing.FillSelectedShape(palette.FillBrush);
        }

        public override void ProcessMouseMove(MouseEventArgs e) { }

        public override void ProcessMouseUp(MouseEventArgs e) { }
    }
}
