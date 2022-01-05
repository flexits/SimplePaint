using System.Windows.Forms;

namespace SimplePaint
{
    /*
     * This static class incapsulates all available drawing tools (one instance for each), 
     * holds the selection of currently assigned tool, and stores the user selected colors 
     * and styles in Palette object. 
     * 
     * This class processes mouse events as an intermediate entity, i.e. passes them to 
     * the currently selected tool for the actual processing.
     * 
     * For drawing tools to fuction properly, they must get a reference to the actual 
     * drawing area (DrawCanvas) and drawing object (IDrawing) by SetDrawing() and SetCanvas()
     * methods correspondingly.
     *
     * © Alexander V. Korostelin, SibSUTIS, Novosibirsk 2021
     */

    internal static class DrawToolBox
    {
        private static IDrawingTool currentTool;
        private static Palette currentPalette;
        private static IDrawing currentDrawing;
        private static DrawCanvas currentCanvas;

        public static Palette CurrentPalette { get => currentPalette; set => currentPalette = value; }

        static DrawToolBox()
        {
            currentPalette = new Palette();
        }

        public static void SetDrawing(IDrawing drawing)
        {
            currentDrawing = drawing;
        }

        public static void SetCanvas(DrawCanvas canvas)
        {
            currentCanvas = canvas;
        }

        public static void Select(DrawingTools tool)
        {
            switch (tool)
            {
                case DrawingTools.None:
                    currentTool = null;
                    break;
                case DrawingTools.Pencil:
                    currentTool = new GenericTool<Line>(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Freehand:
                    currentTool = new GenericTool<Freepath>(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Rectangle:
                    currentTool = new GenericTool<Rectngl>(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Ellipse:
                    currentTool = new GenericTool<Ellipse>(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Eraser:
                    currentTool = new ToolEraser(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Move:
                    currentTool = new ToolCanvasMove(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Selector:
                    currentTool = new ToolShapeSelect(currentPalette, currentCanvas, currentDrawing);
                    break;
                case DrawingTools.Fill:
                    currentTool = new ToolShapeFill(currentPalette, currentCanvas, currentDrawing);
                    break;
            }
        }

        public static void ProcessMouseDown(MouseEventArgs e)
        {
            currentTool?.ProcessMouseDown(e);
        }

        public static void ProcessMouseMove(MouseEventArgs e)
        {
            currentTool?.ProcessMouseMove(e);
        }

        public static void ProcessMouseUp(MouseEventArgs e)
        {
            currentTool?.ProcessMouseUp(e);
        }
    }
}
