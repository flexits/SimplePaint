using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimplePaint
{
    public delegate void UpdateHandler();
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
    }

    class Drawing : IDrawing
    {
        public event UpdateHandler Updated; //TODO send bounding rectangle as an argument to make Inalidate(Rectangle) possible

        private Stack<IDrawable> shapes;

        private Stack<IDrawable> discarded;

        private Bitmap lining;

        public bool DrawingChanged => shapes.Count > 0;

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
            Updated?.Invoke();
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
            discarded.Push(shapes.Pop());
            Updated?.Invoke();
        }

        public void Redo()
        {
            if (discarded.Count == 0)
            {
                return;
            }
            shapes.Push(discarded.Pop());
            Updated?.Invoke();
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
            Updated?.Invoke();
        }

        public void Clear()
        {
            shapes.Clear();
            discarded.Clear();
            Updated?.Invoke();
        }
    }
}
