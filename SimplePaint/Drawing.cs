using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimplePaint
{
    public delegate void UpdateHandler(Rectangle updatedBounds);
    interface IDrawing
    {
        bool DrawingChanged { get; }
        Size Size { get; set; }

        event UpdateHandler Updated;
        void AddShape(IDrawable shape);
        void AddBitmap(Bitmap bitmap, bool resizeDrawing);
        void DrawAll(Graphics drawSurface);
        void Undo();
        void Redo();
        void UndoAll();
        IDrawable SelectShapeByPoint(Point ptToSearch, bool includeInside = false);
        void MoveSelectedShape(Point offset);
        void FillSelectedShape(Brush fill);
        void DiscardSelectedShape();
    }

    class Drawing : IDrawing
    {
        public event UpdateHandler Updated;

        private readonly IRewindableShapesStorage shapes;

        private int currentZOrder;

        private Bitmap lining;

        private int selectedShapeIndex;

        public bool DrawingChanged => shapes.Count > 0 || lining != null;

        public Size Size { get; set; }

        public Drawing()
        {
            shapes = new RewindableShapesStorage();
            currentZOrder = 0;
            selectedShapeIndex = -1;
        }

        public void AddShape(IDrawable shape)
        {
            if (shape == null)
            {
                return;
            }
            shape.ZOrder = currentZOrder++;
            shapes.Add(shape);
            Updated?.Invoke(shape.GetBoundingRectangle());
        }

        public void AddBitmap(Bitmap bitmap, bool resizeDrawing)
        {
            if (bitmap is null)
            {
                return;
            }
            lining = bitmap;
            if (resizeDrawing)
            {
                Size = bitmap.Size;
            }
        }

        public void DrawAll(Graphics drawSurface)
        {
            if (lining != null)
            {
                drawSurface.DrawImage(lining, 0, 0);
            }
            var sortedShapes = shapes.GetSortedContents();
            foreach (IDrawable shape in sortedShapes)
            {
                shape.Draw(drawSurface);
            }
        }

        public void Undo()
        {
            shapes.Rewind();
            //Updated?.Invoke(shape.GetBoundingRectangle());
            Updated?.Invoke(new Rectangle(Point.Empty, Size));
        }

        public void Redo()
        {
            shapes.Forward();
            //Updated?.Invoke(shape.GetBoundingRectangle());
            Updated?.Invoke(new Rectangle(Point.Empty, Size));
        }

        public void UndoAll()
        {
            shapes.RewindFull();
            Updated?.Invoke(new Rectangle(Point.Empty, Size));
        }

        public IDrawable SelectShapeByPoint(Point ptToSearch, bool includeInside)
        {
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                IDrawable shape = shapes.ElementAt(i);
                if (shape.HitTest(ptToSearch, includeInside))
                {
                    selectedShapeIndex = i;
                    return shape;
                }
            }
            selectedShapeIndex = -1;
            return null;
        }

        public void MoveSelectedShape(Point offset)
        {
            if (selectedShapeIndex < 0)
            {
                return;
            }
            IDrawable shape = shapes.ElementAt(selectedShapeIndex).Clone() as IDrawable;
            shape.Move(offset);
            shapes.Update(selectedShapeIndex, shape);
            Updated?.Invoke(new Rectangle(Point.Empty, Size));
        }

        public void FillSelectedShape(Brush fill)
        {
            if (selectedShapeIndex < 0)
            {
                return;
            }
            IDrawable shape = shapes.ElementAt(selectedShapeIndex).Clone() as IDrawable;
            shape.FillBrush = fill;
            shapes.Update(selectedShapeIndex, shape);
            Updated?.Invoke(shape.GetBoundingRectangle());
        }

        public void DiscardSelectedShape()
        {
            if (selectedShapeIndex < 0)
            {
                return;
            }
            IDrawable shape = shapes.ElementAt(selectedShapeIndex);
            shapes.RemoveAt(selectedShapeIndex);
            selectedShapeIndex = -1;
            Updated?.Invoke(shape.GetBoundingRectangle());
        }
    }
}
