using System;
using System.Drawing;

namespace SimplePaint
{
    public static class PointMath
    {
        public static Point Add(Point augend, Point addend)
        {
            return new Point(augend.X + addend.X, augend.Y + addend.Y);
        }

        public static Point Subtract(Point minuend, Point subtrahend)
        {
            return new Point(minuend.X - subtrahend.X, minuend.Y - subtrahend.Y);
        }

        public static Point UnscalePoint(Point scaledPoint, float zoomFactor)
        {
            Point unscaledPoint = Point.Empty;
            unscaledPoint.X = (int)Math.Round(scaledPoint.X / zoomFactor);
            unscaledPoint.Y = (int)Math.Round(scaledPoint.Y / zoomFactor);
            return unscaledPoint;
        }

        public static Point ScalePoint(Point unscaledPoint, float zoomFactor)
        {
            Point scaledPoint = Point.Empty;
            scaledPoint.X = (int)Math.Round(unscaledPoint.X * zoomFactor);
            scaledPoint.Y = (int)Math.Round(unscaledPoint.Y * zoomFactor);
            return scaledPoint;
        }
    }
}
