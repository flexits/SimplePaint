using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace SimplePaint
{
    /*
     * Each graphics primitive existing on the drawing surface is presented
     * by the Shape class, that implements the IDrawable interface. In its turn,
     * the IDrawable implements system's ICloneable interface, producing a deep
     * copy of the object.
     * 
     * Base constructor of the Shape class gets non-nullable Pen and nullable Brush
     * arguments. Later the corresponding properties may be modified by SetPen() 
     * and SetFill() methods correspondingly.
     * 
     * Actual classes of real graphics primitives are derived from abstract class Shape.
     * The constructor of such a class contains at least one additional mandatory
     * agrument - that is the starting point where the geometric figure "grows" from.
     * 
     * Geometrical shapes may be forced to some presets (line to 90 and 45 degrees 
     * X- and Y- axis relatively, rectangle to square, ellipe to circle) by setting the
     * AddPoint(Point pathPoint, bool snapToStraight) snapToStraight argument true. If so,
     * the provided pathPoint will be modified correspondingly.
     * 
     * © Alexander V. Korostelin, SibSUTIS, Novosibirsk 2021
     */

    public interface IDrawable : ICloneable
    {
        int ZOrder { get; set; }                                //sets object's position on Z axis
        void SetFill(Brush fillBrush);                          //sets brush to fill the shape (no fill if null)
        void SetPen(Pen outlinePen);                            //sets pen to draw the shape (exception if null)
        void AddPoint(Point pathPoint, bool snapToStraight);    //adds a point to the current object structure
        void Draw(Graphics drawSurface);                        //draws current object onto the provided surface
        Rectangle GetBoundingRectangle();                       //returns a minimum rectanle containing the object
        bool HitTest(Point point, bool includeInside);          //true if the provided point is included in the object's outline (or also inside of the object if includeInside)
        void Move(Point offset);                                //moves the starting point of the object by offset (thus moving the full figure)
    }

    internal abstract class Shape : IDrawable
    {
        private protected Pen DrawingPen { get; set; }
        private protected Brush FillBrush { get; set; }
        public int ZOrder { get; set; } = 0;

        private protected Shape(Pen pen, Brush brush)
        {
            if (pen is null)
            {
                throw new ArgumentNullException();
            }
            DrawingPen = pen;
            FillBrush = brush;
        }

        public abstract void AddPoint(Point pathPoint, bool snapToStraight);
        public abstract void Draw(Graphics drawSurface);
        public abstract Rectangle GetBoundingRectangle();
        public abstract bool HitTest(Point point, bool includeInside);
        public abstract void Move(Point offset);

        public void SetFill(Brush fillBrush)
        {
            FillBrush = fillBrush;
        }

        public void SetPen(Pen outlinePen)
        {
            if (outlinePen is null)
            {
                return;
            }
            DrawingPen = outlinePen;
        }

        public object Clone()                                   //a deep copy of the object
        {
            Shape newShape = this.MemberwiseClone() as Shape;
            if (DrawingPen is null)
            {
                newShape.DrawingPen = null;
            }
            else
            {
                newShape.DrawingPen = DrawingPen.Clone() as Pen;
            }
            if (FillBrush is null)
            {
                newShape.FillBrush = null;
            }
            else
            {
                newShape.FillBrush = FillBrush.Clone() as Brush;
            }
            return newShape;
        }
    }

    internal class Line : Shape
    {
        //the line is considered as a hypotenuse, and its
        //projections onto X- and Y- axis as cathetuses.
        //Thus the cathetuses ratio is tangent of adjacent angle.
        //Let the snap-on angle be +/-15 degrees, then the line
        //will be snap on 15,30,60,75 degress deflection
        //(regardless the sign).

        private const float Tg15 = 0.27F;
        private const float Tg75 = 3.73F;
        private const float Tg30 = 0.58F;
        private const float Tg60 = 1.73F;

        private protected Point startPt;
        private protected Point endPt;

        public Line(Pen pen, Brush brush, Point startPoint) : base(pen, brush)
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
                //if X or Y coords of two points are equal, the line is parallel to the axis
            }
            int width = endPt.X - startPt.X;
            int height = endPt.Y - startPt.Y;
            float tga = Math.Abs((float)width / height);
            if (tga < Tg15)
            {
                //vertical snap
                endPt.X = startPt.X;
            }
            else if (tga > Tg75)
            {
                //horizontal snap
                endPt.Y = startPt.Y;
            }
            else if (tga > Tg30 || tga < Tg60)
            {
                //45% snap
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

        public override bool HitTest(Point ptToTest, bool includeInside)
        {
            GraphicsPath gpath = new GraphicsPath();
            gpath.AddLine(startPt, endPt);
            return gpath.IsOutlineVisible(ptToTest, DrawingPen);
        }

        public override void Move(Point offset)
        {
            startPt.Offset(offset);
            endPt.Offset(offset);
        }
    }

    internal class Freepath : Shape
    { 
        private protected List<Point> pathPoints;
        
        public Freepath(Pen pen, Brush brush, Point startPoint) : base(pen, brush)
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

        public override bool HitTest(Point ptToTest, bool includeInside)
        {
            GraphicsPath gpath = new GraphicsPath();
            gpath.AddLines(pathPoints.ToArray());
            return gpath.IsOutlineVisible(ptToTest, DrawingPen);
        }

        public override void Move(Point offset)
        {
            foreach (Point p in pathPoints)
            {
                p.Offset(offset);
            }
        }
    }

    internal class Rectngl : Shape
    {
        private protected Point givenStartPt;

        private protected Point startPt;
        private protected Point endPt;

        public Rectngl(Pen pen, Brush brush, Point startPoint) : base(pen, brush)
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
        }

        protected Rectangle GenerateRect()
        {
            return new Rectangle(startPt, new Size(endPt.X - startPt.X, endPt.Y - startPt.Y));
        }

        public override void Draw(Graphics drawSurface)
        {
            if (startPt == endPt)
            {
                return;
            }
            Rectangle rect = GenerateRect();
            drawSurface.DrawRectangle(DrawingPen, rect);
            if (FillBrush != null)
            {
                drawSurface.FillRectangle(FillBrush, rect);
            }
        }

        public override Rectangle GetBoundingRectangle()
        {
            return GenerateRect();
        }

        public override bool HitTest(Point ptToTest, bool includeInside)
        {
            GraphicsPath gpath = new GraphicsPath();
            gpath.AddRectangle(GenerateRect());
            bool result = gpath.IsOutlineVisible(ptToTest, DrawingPen);
            if (includeInside || FillBrush != null)
            {
                result = result || gpath.IsVisible(ptToTest);
            }
            return result;
        }

        public override void Move(Point offset)
        {
            startPt.Offset(offset);
            endPt.Offset(offset);
        }
    }

    internal class Ellipse : Rectngl
    {
        public Ellipse(Pen pen, Brush brush, Point startPoint) : base(pen, brush, startPoint) { }

        public override void Draw(Graphics drawSurface)
        {
            if (startPt == endPt)
            {
                return;
            }
            Rectangle rect = GenerateRect();
            drawSurface.DrawEllipse(DrawingPen, rect);
            if (FillBrush != null)
            {
                drawSurface.FillEllipse(FillBrush, rect);
            }
        }

        public override bool HitTest(Point ptToTest, bool includeInside)
        {
            GraphicsPath gpath = new GraphicsPath();
            gpath.AddEllipse(GenerateRect());
            bool result = gpath.IsOutlineVisible(ptToTest, DrawingPen);
            if (includeInside || FillBrush != null)
            {
                result = result || gpath.IsVisible(ptToTest);
            }
            return result;
        }
    }
}
