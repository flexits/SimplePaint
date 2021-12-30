using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace SimplePaint
{
    public interface IDrawable : ICloneable
    {
        void AddPoint(Point pathPoint);
        void Draw(Graphics drawSurface, bool snapOn);
        Rectangle GetBoundingRectangle();
    }

    internal abstract class Shape : IDrawable
    {
        public Pen DrawingPen { get; set; }

        private protected Shape(Pen pen)
        {
            DrawingPen = pen;
        }

        public abstract void AddPoint(Point pathPoint);
        public abstract void Draw(Graphics drawSurface, bool snapOn);
        public abstract Rectangle GetBoundingRectangle();

        public object Clone()
        {
            //clone Pen too!
            return this.MemberwiseClone();
        }
    }

    internal class Line : Shape
    {
        //snap-on angle = 15 
        private const float Tg15 = 0.27F;
        private const float Tg75 = 3.73F;
        private const float Tg30 = 0.58F;
        private const float Tg60 = 1.73F;

        private protected Point startPt;
        private protected Point endPt;

        public Line(Pen pen, Point startPoint) : base(pen)
        {
            startPt = startPoint;
            endPt = startPoint;
        }

        public override void AddPoint(Point pathPoint)
        {
            endPt = pathPoint;
        }

        public override void Draw(Graphics drawSurface, bool snapOn)
        {
            if (startPt == endPt)
            {
                return;
            }
            if (snapOn)
            {
                if (endPt.X != startPt.X && endPt.Y != startPt.Y)
                {
                    int width = endPt.X - startPt.X;
                    int height = endPt.Y - startPt.Y;
                    float tga = Math.Abs((float)width / height);
                    if (tga < Tg15)
                    {
                        //vertical
                        endPt.X = startPt.X;
                    }
                    else if (tga > Tg75)
                    {
                        //horizontal
                        endPt.Y = startPt.Y; 
                    }
                    else if (tga > Tg30 || tga < Tg60)
                    {
                        //45%
                        int hyp = (int)Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));
                        endPt.X = startPt.X + hyp * Math.Sign(width);
                        endPt.Y = startPt.Y + hyp * Math.Sign(height);
                    }
                }
            }
            drawSurface.DrawLine(DrawingPen, startPt, endPt);
        }

        public override Rectangle GetBoundingRectangle()
        {
            int coordX = Math.Min(startPt.X, endPt.X);
            int coordY = Math.Min(startPt.Y, endPt.Y);
            int width = Math.Abs(endPt.X - startPt.X);
            int height = Math.Abs(endPt.Y - startPt.Y);
            return new Rectangle(coordX, coordY, width, height);
        }
    }

    internal class Freepath : Shape
    { 
        private protected List<Point> pathPoints;
        
        public Freepath(Pen pen, Point startPoint) : base(pen)
        {
            pathPoints = new List<Point>();
            AddPoint(startPoint);
        }

        public override void AddPoint(Point pathPoint)
        {
            pathPoints.Add(pathPoint);
        }

        public override void Draw(Graphics drawSurface, bool snapOn)
        {
            if (pathPoints.Count <= 1)
            {
                return;
            }
            drawSurface.DrawLines(DrawingPen, pathPoints.ToArray());
        }

        public override Rectangle GetBoundingRectangle()
        {
            int minX = pathPoints.Min(n => n.X);
            int minY = pathPoints.Max(n => n.Y);
            int maxX = pathPoints.Max(n => n.X);
            int maxY = pathPoints.Max(n => n.Y);
            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }
    }

    internal class Rectngl : Shape
    {
        private protected Point startPt;
        private protected Point endPt;
        private protected Rectangle rect = Rectangle.Empty;

        public Rectngl(Pen pen, Point startPoint) : base(pen)
        {
            startPt = startPoint;
            endPt = startPoint;
        }

        public override void AddPoint(Point pathPoint)
        {
            endPt = pathPoint;
        }

        public override void Draw(Graphics drawSurface, bool snapOn)
        {
            if (startPt == endPt)
            {
                return;
            }
            int width = endPt.X - startPt.X;
            int height = endPt.Y - startPt.Y;
            int signY = Math.Sign(height);
            int signX = Math.Sign(width);
            width = Math.Abs(width);
            height = Math.Abs(height);
            if (snapOn && width != height)
            {
                width = height = Math.Max(width, height);
            }
            int stX = startPt.X;
            if (signX < 0)
            {
                stX -= width;
            }
            int stY = startPt.Y;
            if (signY < 0)
            {
                stY -= height;
            }
            rect = new Rectangle(stX, stY, width, height);
            drawSurface.DrawRectangle(DrawingPen, rect);
        }

        public override Rectangle GetBoundingRectangle()
        {
            return rect;
        }
    }

    internal class Ellipse : Rectngl
    {
        public Ellipse(Pen pen, Point startPoint) : base(pen, startPoint) { }

        public override void Draw(Graphics drawSurface, bool snapOn)
        {
            if (startPt == endPt)
            {
                return;
            }
            int width = endPt.X - startPt.X;
            int height = endPt.Y - startPt.Y;
            int signY = Math.Sign(height);
            int signX = Math.Sign(width);
            width = Math.Abs(width);
            height = Math.Abs(height);
            if (snapOn && width != height)
            {
                width = height = Math.Max(width, height);
            }
            int stX = startPt.X;
            if (signX < 0)
            {
                stX -= width;
            }
            int stY = startPt.Y;
            if (signY < 0)
            {
                stY -= height;
            }
            rect = new Rectangle(stX, stY, width, height);
            drawSurface.DrawEllipse(DrawingPen, rect);
        }
    }
}
