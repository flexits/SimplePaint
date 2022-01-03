using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimplePaint
{
    internal class Palette
    {
        public Palette()
        {
            ForegroundPen = new Pen(Color.Black, 1);
            BackgroundPen = new Pen(Color.White, 1);
            FillBrush = null;
        }
        public Pen ForegroundPen { get; set; }
        public Pen BackgroundPen { get; set; }
        public Brush FillBrush { get; set; }
    }

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
