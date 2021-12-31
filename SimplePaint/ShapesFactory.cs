using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimplePaint
{
    public static class ShapesFactory
    {
        private static IDrawable currentShape = null;

        public static void Init<T>(Pen pen, Brush brush, Point startPt) where T : IDrawable
        {
            object[] args = { null, brush, startPt };
            if (pen is null)
            {
                args[0] = new Pen(Color.Black, 1)
                {
                    DashStyle = DashStyle.Solid
                };
            }
            else
            {
                args[0] = (Pen)pen.Clone();
            }
            currentShape = (T)Activator.CreateInstance(typeof(T), args);
        }

        public static void AddPoint(Point nextPt, bool snapToStraight)
        {
            if (currentShape is null)
            {
                throw new NullReferenceException();
            }
            currentShape.AddPoint(nextPt, snapToStraight);
        }

        public static IDrawable Finish()
        {
            if (currentShape is null)
            {
                throw new NullReferenceException();
            }
            return currentShape;
        }
    }
}
