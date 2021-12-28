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

        event UpdateHandler Updated;
        void AddShape(IDrawable shape);
        void DrawAll(Graphics drawSurface);
        void Undo();
        void Redo();
        void UndoAll();
        void Clear();
    }

    class Drawing : IDrawing
    {
        public event UpdateHandler Updated; //TODO send bounding rectangle
        private Stack<IDrawable> shapes = new Stack<IDrawable>();
        private Stack<IDrawable> discarded = new Stack<IDrawable>();

        public bool DrawingChanged => shapes.Count > 0;

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

        public void DrawAll(Graphics drawSurface)
        {
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
