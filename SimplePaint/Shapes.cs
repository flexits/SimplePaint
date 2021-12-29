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

        public abstract void AddPoint(Point pathPoint);
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
        private protected Point startPt { get; set; }
        private protected Point endPt { get; set; }

        public Line(Pen pen, Point startPoint) : base(pen)
        {
            startPt = startPoint;
            endPt = startPoint;
        }

        public override void AddPoint(Point pathPoint)
        {
            endPt = pathPoint;
        }

        public override void Draw(Graphics drawSurface)
        {
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

        /*public Point[] GetPoints(float zoomFactor = 1.0F)
        {
            var result = pathPoints.Select(point => new Point((int)Math.Round(point.X * zoomFactor), (int)Math.Round(point.Y * zoomFactor)));
            return result.ToArray();
        }*/

        public override void Draw(Graphics drawSurface)
        {
            drawSurface.DrawLines(DrawingPen, pathPoints.ToArray());
        }

        public override Rectangle GetBoundingRectangle()
        {
            //amongst all points find the biggest and smallest X and Y
            //then calculate rectangle
            return Rectangle.Empty;
        }
    }
}
