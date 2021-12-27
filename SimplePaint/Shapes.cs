﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace SimplePaint
{
    interface IDrawable : ICloneable
    {
        void Draw(Graphics drawSurface);
        Rectangle GetBoundingRectangle();
    }

    abstract class Shape : IDrawable
    {
        public Pen DrawingPen { get; set; }

        protected Shape(Pen pen)
        {
            DrawingPen = pen;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        
        public abstract void Draw(Graphics drawSurface);
        public abstract Rectangle GetBoundingRectangle();
    }

    class Line : Shape
    {
        protected Point startPt { get; set; }
        protected Point endPt { get; set; }

        public Line(Pen pen, Point startPoint, Point endPoint) : base(pen)
        {
            startPt = startPoint;
            endPt = endPoint;
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

    class Freepath : Shape
    {
        private List<Point> pathPoints;
        
        public Freepath(Pen pen, Point startPoint) : base(pen)
        {
            pathPoints = new List<Point>();
            AddPoint(startPoint);
        }

        public void AddPoint(Point pathPoint)
        {
            pathPoints.Add(pathPoint);
        }

        public Point[] GetPoints(float zoomFactor = 1.0F)
        {
            var result = pathPoints.Select(point => new Point((int)Math.Round(point.X * zoomFactor), (int)Math.Round(point.Y * zoomFactor)));
            return result.ToArray();
        }

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
