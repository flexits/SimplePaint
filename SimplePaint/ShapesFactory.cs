using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ShapesLibrary;

namespace SimplePaint
{
    /*
     * This static class generates new IDrawable objects of given type T.
     * 
     * Firstly the object is initiated by Init<T>() method, with the starting point,
     * pen and brush given (it's where the object instance is actually created, 
     * hence the object's constructor is called). If provided pen is null, a default 
     * one will be used (black 1px). If provided brush is null, the shape will have no fill.
     * 
     * Then, any quantity of additional points can be added by AddPoint() method -
     * actualli it's a wrapper for IDrawable.AddPoint().
     * Finally, the created object can be passed out by calling Finish().
     * 
     * Calling any of these methods without preceding Init<T>() generates NullReferenceException.
     * Omitting Finish() leaves the newly created instance without active reference thus
     * causing garbage collector to destroy it. 
     * 
     * © Alexander V. Korostelin, SibSUTIS, Novosibirsk 2021
     */

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
