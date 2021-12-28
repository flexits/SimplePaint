using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimplePaint
{
    public static class ShapesFactory
    {
        private static IDrawable currentShape;
        private static Pen currentPen;

        static ShapesFactory()
        {
            currentShape = null;
            currentPen = new Pen(Color.Black, 1)
            {
                DashStyle = DashStyle.Solid
            };
        }

        public static void Init(Pen pen, Shapes shapeType, Point startPt)
        {
            if (pen != null)
            {
                currentPen = pen;
            }
            switch (shapeType)
            {
                case Shapes.LineStraight:
                    currentShape = new Line((Pen)currentPen.Clone(), startPt);
                    break;
                case Shapes.LineFreehand:
                    currentShape = new Freepath((Pen)currentPen.Clone(), startPt);
                    break;
                default:
                    currentShape = null;
                    return;
            }
        }

        public static void Continue(Point nextPt)
        {
            if (currentShape is null)
            {
                throw new NullReferenceException();
            }
            switch (currentShape.ShapeType)
            {
                case Shapes.LineStraight:
                    (currentShape as Line).ChangeEndPoint(nextPt);
                    break;
                case Shapes.LineFreehand:
                    (currentShape as Freepath).AddPoint(nextPt);
                    break;
                default:
                    return;
            }
        }

        public static IDrawable Finish(Point endPt)
        {
            if (currentShape is null)
            {
                throw new NullReferenceException();
            }
            switch (currentShape.ShapeType)
            {
                case Shapes.LineStraight:
                    (currentShape as Line).ChangeEndPoint(endPt);
                    break;
                case Shapes.LineFreehand:
                    (currentShape as Freepath).AddPoint(endPt);
                    break;
            }
            return currentShape;
        }
    }
}
