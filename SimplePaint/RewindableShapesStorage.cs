using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePaint
{
    internal interface IRewindableShapesStorage
    {
        int Count { get; }
        void Add(IDrawable shape);
        IEnumerable<IDrawable> GetSortedContents();
        IDrawable ElementAt(int index);
        void Update(int index, IDrawable newshape);
        void RemoveAt(int index);
        void Rewind();
        void Forward();
        void RewindFull();
    }

    internal class RewindableShapesStorage : IRewindableShapesStorage
    {
        private enum DrawingOperations
        {
            Create,
            Update,
            Delete
        }

        private readonly List<IDrawable> shapes;

        private readonly List<(IDrawable, int, DrawingOperations)> timeline = new List<(IDrawable, int, DrawingOperations)>();

        private int currtime;

        public RewindableShapesStorage()
        {
            shapes = new List<IDrawable>();
            currtime = 0;
        }

        public int Count => shapes.Count;

        public void Add(IDrawable shape)
        {
            if (shape is null)
            {
                return;
            }
            shapes.Add(shape);
            timeline.Insert(currtime, (null, shapes.Count - 1, DrawingOperations.Create));
            currtime++;
            timeline.RemoveRange(currtime, timeline.Count - currtime);
        }

        public IEnumerable<IDrawable> GetSortedContents()
        {
            return shapes.OrderBy(z => z.ZOrder);
        }

        public IDrawable ElementAt(int index)
        {
            if (index < 0 || index >= shapes.Count)
            {
                return null;
            }
            return shapes.ElementAt(index);
        }

        public void Update(int index, IDrawable newshape)
        {
            if (index < 0 || index >= shapes.Count || newshape is null)
            {
                return;
            }
            IDrawable shape = shapes[index];
            shapes[index] = newshape;
            timeline.Insert(currtime, (shape, index, DrawingOperations.Update));
            currtime++;
        }

        public void RemoveAt(int index)
        {
            IDrawable shape = shapes.ElementAt(index);
            if (shape is null)
            {
                return;
            }
            timeline.Insert(currtime, (shape, index, DrawingOperations.Delete));
            currtime++;
            shapes.RemoveAt(index);
        }

        private void FallbackToTimeline(int timelineIndex)
        {
            int currentIndex = timeline[timelineIndex].Item2;
            IDrawable currentShape = timeline[timelineIndex].Item1;
            DrawingOperations currentOperation = timeline[timelineIndex].Item3;

            if (currentIndex < 0 || currentIndex > shapes.Count)
            {
                return;
            }

            switch (currentOperation)
            {
                case DrawingOperations.Create:
                    IDrawable shapetosave = shapes.ElementAt(currentIndex);
                    shapes.RemoveAt(currentIndex);
                    timeline[timelineIndex] = (shapetosave, currentIndex, DrawingOperations.Delete);
                    break;
                case DrawingOperations.Update:
                    shapetosave = shapes[currentIndex];
                    shapes[currentIndex] = currentShape;
                    timeline[timelineIndex] = (shapetosave, currentIndex, DrawingOperations.Update);
                    break;
                case DrawingOperations.Delete:
                    shapes.Insert(currentIndex, currentShape);
                    timeline[timelineIndex] = (null, currentIndex, DrawingOperations.Create);
                    break;
            }
        }

        public void Rewind()
        {
            if (currtime <= 0)
            {
                return;
            }

            FallbackToTimeline(currtime - 1);

            currtime--;
        }

        public void Forward()
        {
            if (currtime >= timeline.Count)
            {
                return;
            }

            FallbackToTimeline(currtime);

            currtime++;
        }

        public void RewindFull()
        {
            while (currtime > 0)
            {
                Rewind();
            }
        }
    }
}
