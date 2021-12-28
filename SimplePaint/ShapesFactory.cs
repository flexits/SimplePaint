using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
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

        public static void Init<T>(Pen pen, Point startPt) where T : IDrawable
        {
            if (pen != null)
            {
                currentPen = pen;
            }
            object[] args = { (Pen)currentPen.Clone(), startPt };
            currentShape = (T)Activator.CreateInstance(typeof(T), args);
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
