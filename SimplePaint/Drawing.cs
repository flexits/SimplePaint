using System.Drawing;

namespace SimplePaint
{
    /*
     * Incapsulates drawing contents (graphics primitives) as a collection of IDrawable objects
     * and provides methods to operate on them.
     * 
     * © Alexander V. Korostelin, SibSUTIS, Novosibirsk 2021
     */

    public delegate void UpdateHandler(Rectangle updatedBounds);

    internal interface IDrawing
    {
        event UpdateHandler Updated;    //triggered upon any visualizable contents modification
        bool DrawingChanged { get; }    //true if the drawing object was modified after its creation
        Size Size { get; set; }         //size of the drawing area in px
        void AddShape(IDrawable shape); //add a graphics primitive object to the drawing
        void AddBitmap(Bitmap bitmap, bool resizeDrawing);  //add a bitmap as background, if resizeDrawing - set the drawing size equal to the bitmap's
        void DrawAll(Graphics drawSurface); //draw all containing objects preserving Z order on the provided Graphics 
        void Undo();                    //undo last modification
        void Redo();                    //redo undone actions 
        void UndoAll();                 //undo all actions - revert to claen original state
        IDrawable SelectShapeByPoint(Point ptToSearch, bool includeInside = false); //mark an object as selected and return it, if the provided point
                                                                                    //belongs to the object's outline (or is included inside the object);
                                                                                    //otherwise deselect the previously selected one and return null
        void MoveSelectedShape(Point offset); //move the object marked as selected by the provided offset
        void FillSelectedShape(Brush fill);   //fill the object marked as selected with the provided brush
        void DiscardSelectedShape();          //remove the object marked as selected (this action may be undone)
    }

    internal class Drawing : IDrawing
    {
        public event UpdateHandler Updated;

        public bool DrawingChanged => shapes.Count > 0 || lining != null;

        public Size Size { get; set; }

        private readonly IRewindableShapesStorage shapes;

        private int currentZOrder;

        private Bitmap lining;

        private int selectedShapeIndex;

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
            Updated?.Invoke(new Rectangle(Point.Empty, Size));
        }

        public void Redo()
        {
            shapes.Forward();
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
            //TODO color outline ot the moving shape
            shape.Move(offset);
            shapes.Replace(selectedShapeIndex, shape);
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
            shapes.Replace(selectedShapeIndex, shape);
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
