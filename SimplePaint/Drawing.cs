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
        IDrawable GetShapeByPoint(Point ptToSearch);
    }

    class Drawing : IDrawing
    {
        public event UpdateHandler Updated;

        private Stack<IDrawable> shapes;

        private Stack<IDrawable> discarded;

        private Bitmap lining;

        public bool DrawingChanged => shapes.Count > 0 || lining != null;

        public Size Size { get; set; }

        public Drawing()
        {
            shapes = new Stack<IDrawable>();
            discarded = new Stack<IDrawable>();
        }

        public void AddShape(IDrawable shape)
        {
            if (shape == null)
            {
                return;
            }
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
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                shapes.ElementAt(i).Draw(drawSurface);
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
            Stack<IDrawable> temp = new Stack<IDrawable>();
            while (shapes.Count > 0)
            {
                temp.Push(shapes.Pop());
            }
            while (temp.Count > 0)
            {
                discarded.Push(temp.Pop());
            }
            Updated?.Invoke(new Rectangle(Point.Empty, Size));
        }

        public void Clear()
        {
            shapes.Clear();
            discarded.Clear();
            Updated?.Invoke(new Rectangle(Point.Empty, Size));
        }

        public IDrawable GetShapeByPoint(Point ptToSearch)
        {
            foreach (IDrawable shape in shapes)
            {
                if (shape.HitTest(ptToSearch))
                {
                    return shape;
                }
            }
            return null;
        }
    }
}
