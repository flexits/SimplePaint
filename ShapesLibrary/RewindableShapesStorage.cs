using System.Collections.Generic;
using System.Linq;

namespace ShapesLibrary
{
    /*
     * Storage of IDrawable objects. Provides methods to add, modify and remove
     * containing objects, storing the history of these actions to make undo/redo operations possible.
     * Redo history is cleared after adding a new object to avoid undecidable condition.
     * 
     * © Alexander V. Korostelin, SibSUTIS, Novosibirsk 2021
     */

    public interface IRewindableShapesStorage
    {
        int Count { get; }                          //number of objects in the collection
        void Add(IDrawable shape);                  //add an object to the collection
        IEnumerable<IDrawable> GetSortedContents(); //get all contained objects in Z order
        IDrawable ElementAt(int index);             //get an object by its index in collection
        void Replace(int index, IDrawable newshape); //replace an object in the collection by the provided one
        void RemoveAt(int index);                   //remove an object by its index
        void Rewind();                              //one step back - undo an action
        void Forward();                             //one step forward - redo an action
        void RewindFull();                          //revert to the start - undo all
    }

    public class RewindableShapesStorage : IRewindableShapesStorage
    {
        /*
         * Current set of IDrawable objects is represented by List<IDrawable> shapes collection.
         * 
         * Set of actions is represented by a timeline List<(IDrawable, int, DrawingOperations)> timeline.
         * Each entry in the timeline collection represents a snapshot of an action. 
         * Each snapshot contains the previous IDrawable object (i.e. object that was contained in the shapes collection 
         * before an action took place), its index in the shapes collection and an action attribute.
         * 
         * Also there's a currtime variable, that points to a specific shapshop in timeline, holding it index.
         * 
         * When a new action is done, a snapshot is being added to the timeline by currtime index.
         * When an action is reverted, currtime decreases, and the two objects with identical indices are exchanged - 
         * one from timeline and other from the snapshot. Whed an action it redone, the same process takes place, but currtime increases.
         * 
         * So the timeline may be seen as a tape with snapshots, movable forwards and backwards. Exchanging objects with current snapshot
         * makes possible to store the history of actions.
         */

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

        public void Replace(int index, IDrawable newshape)
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

        private void ExchangeWithSnapshot(int timelineIndex)
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
            ExchangeWithSnapshot(--currtime);
        }

        public void Forward()
        {
            if (currtime >= timeline.Count)
            {
                return;
            }
            ExchangeWithSnapshot(currtime++);
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
