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
        void AddPoint(Point pathPoint, bool snapToStraight);
        void Draw(Graphics drawSurface);
        Rectangle GetBoundingRectangle();
    }

    internal abstract class Shape : IDrawable
    {
        public Pen DrawingPen { get; set; }

        private protected Shape(Pen pen)
        {
            DrawingPen = pen;
        }

        public abstract void AddPoint(Point pathPoint, bool snapToStraight);
        public abstract void Draw(Graphics drawSurface);
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

        public override void AddPoint(Point pathPoint, bool snapToStraight)
        {
            if (startPt == pathPoint)
            {
                return;
            }
            endPt = pathPoint;
            if (!snapToStraight || endPt.X == startPt.X || endPt.Y == startPt.Y)
            {
                return;
            }
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

        public override void Draw(Graphics drawSurface)
        {
            if (startPt == endPt)
            {
                return;
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
            pathPoints.Add(startPoint);
        }

        public override void AddPoint(Point pathPoint, bool snapToStraight)
        {
            pathPoints.Add(pathPoint);
        }

        public override void Draw(Graphics drawSurface)
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
        private protected Point givenStartPt;

        private protected Point startPt;
        private protected Point endPt;

        public Rectngl(Pen pen, Point startPoint) : base(pen)
        {
            givenStartPt = startPoint;
        }

        public override void AddPoint(Point addPt, bool snapToStraight)
        {
            int width = addPt.X - givenStartPt.X;
            int height = addPt.Y - givenStartPt.Y;
            int signX = Math.Sign(width);
            int signY = Math.Sign(height);            
            width = Math.Abs(width);
            height = Math.Abs(height);
            if (snapToStraight && width != height)
            {
                width = height = Math.Max(width, height);
            }
            startPt.X = givenStartPt.X;
            if (signX < 0)
            {
                startPt.X -= width;
            }
            startPt.Y = givenStartPt.Y;
            if (signY < 0)
            {
                startPt.Y -= height;
            }
            endPt.X = startPt.X + width;
            endPt.Y = startPt.Y + height;
            /*It works but adding snapToStraight is complicated
            int width = addPt.X - givenStartPt.X;
            int height = addPt.Y - givenStartPt.Y;
            startPt.X = givenStartPt.X + Math.Min(0, width);
            startPt.Y = givenStartPt.Y + Math.Min(0, height);
            endPt.X = startPt.X + Math.Abs(width);
            endPt.Y = startPt.Y + Math.Abs(height);*/
        }

        public override void Draw(Graphics drawSurface)
        {
            if (startPt == endPt)
            {
                return;
            }
            Rectangle rect = new Rectangle(startPt, new Size(endPt.X - startPt.X, endPt.Y - startPt.Y));
            drawSurface.DrawRectangle(DrawingPen, rect);
        }

        public override Rectangle GetBoundingRectangle()
        {
            return new Rectangle(startPt, new Size(endPt.X - startPt.X, endPt.Y - startPt.Y));
        }
    }

    internal class Ellipse : Rectngl
    {
        public Ellipse(Pen pen, Point startPoint) : base(pen, startPoint) { }

        public override void Draw(Graphics drawSurface)
        {
            if (startPt == endPt)
            {
                return;
            }
            Rectangle rect = new Rectangle(startPt, new Size(endPt.X - startPt.X, endPt.Y - startPt.Y));
            drawSurface.DrawEllipse(DrawingPen, rect);
        }
    }
}
