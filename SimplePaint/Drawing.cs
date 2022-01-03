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
        void Clear();
        IDrawable SelectShapeByPoint(Point ptToSearch, bool includeInside = false);
        void MoveSelectedShape(Point offset);
        void FillSelectedShape(Brush fill);
        void DiscardSelectedShape();
    }

    class Drawing : IDrawing
    {
        public event UpdateHandler Updated;

        private readonly StackList<IDrawable> shapes;

        private readonly StackList<IDrawable> discarded;

        private int currentZOrder;

        private Bitmap lining;

        private int selectedShapeIndex;

        public bool DrawingChanged => shapes.Count > 0 || lining != null;

        public Size Size { get; set; }

        public Drawing()
        {
            shapes = new StackList<IDrawable>();
            discarded = new StackList<IDrawable>();
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
            shapes.Push(shape);
            discarded.Clear();
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
            var sortedShapes = shapes.OrderBy(z => z.ZOrder);
            foreach (IDrawable shape in sortedShapes)
            {
                shape.Draw(drawSurface);
            }
        }

        public void Undo()
        {
            if (shapes.Count == 0)
            {
                return;
            }
            IDrawable shape = shapes.Pop();
            discarded.Push(shape);
            Updated?.Invoke(shape.GetBoundingRectangle());
        }

        public void Redo()
        {
            if (discarded.Count == 0)
            {
                return;
            }
            IDrawable shape = discarded.Pop();
            shapes.Push(shape);
            Updated?.Invoke(shape.GetBoundingRectangle());
        }

        public void UndoAll()
        {
            if (shapes.Count == 0)
            {
                return;
            }
            discarded.Clear();
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                discarded.Push(shapes.ElementAt(i));
            }
            shapes.Clear();
            Updated?.Invoke(new Rectangle(Point.Empty, Size));
        }

        public void Clear()
        {
            shapes.Clear();
            discarded.Clear();
            currentZOrder = 0;
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
            IDrawable shape = shapes.ElementAt(selectedShapeIndex);
            //TODO undo and redo operations
            shape.Move(offset);
            Updated?.Invoke(new Rectangle(Point.Empty, Size));
        }

        public void FillSelectedShape(Brush fill)
        {
            if (selectedShapeIndex < 0)
            {
                return;
            }
            IDrawable shape = shapes.ElementAt(selectedShapeIndex);
            //TODO undo and redo operations
            shape.FillBrush = fill;
            Updated?.Invoke(shape.GetBoundingRectangle());
        }

        public void DiscardSelectedShape()
        {
            if (selectedShapeIndex < 0)
            {
                return;
            }
            IDrawable shape = shapes.ElementAt(selectedShapeIndex);
            discarded.Push(shape); // it will work on Redo(), not Undo()
            shapes.RemoveAt(selectedShapeIndex);
            selectedShapeIndex = -1;
            Updated?.Invoke(shape.GetBoundingRectangle());
        }
    }
}
