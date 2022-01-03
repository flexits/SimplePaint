using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class DrawCanvas : UserControl
    {
        private const float DEFAULT_ZOOM_FACTOR = 1.0F;
        private const float ZOOM_STEP = 0.1F;

        public float CanvasZoomFactor { get; set; } = DEFAULT_ZOOM_FACTOR;

        public SmoothingMode CanvasSmoothing { get; set; } = SmoothingMode.None;

        public Size CanvasSizeOriginal { get; private set; }

        public event PaintEventHandler ShapesDrawRequest;

        public DrawCanvas()
        {
            InitializeComponent();
            DoubleBuffered = true;
            CanvasSizeOriginal = Size; //needed for VS Constructor
        }

        public void SetSize(Size size)
        {
            CanvasSizeOriginal = size;
            this.Size = size;
        }

        public void ZoomIn()
        {
            CanvasZoomFactor += ZOOM_STEP;
            Invalidate();
        }

        public void ZoomOut()
        {
            if (CanvasZoomFactor <= ZOOM_STEP)
            {
                return;
            }
            CanvasZoomFactor -= ZOOM_STEP;
            Invalidate();
        }

        public void ZoomReset()
        {
            CanvasZoomFactor = 1.0F;
            Invalidate();
        }

        public Bitmap GetBitmap()
        {
            ZoomReset();
            Bitmap btmp = new Bitmap(Width, Height, CreateGraphics());
            DrawToBitmap(btmp, new Rectangle(0, 0, Width, Height));
            return btmp;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = CanvasSmoothing;
            e.Graphics.ScaleTransform(CanvasZoomFactor, CanvasZoomFactor);
            ShapesDrawRequest?.Invoke(this, e);
            Size = new Size((int)(CanvasSizeOriginal.Width * CanvasZoomFactor), (int)(CanvasSizeOriginal.Height * CanvasZoomFactor));
        }

        public event MouseEventHandler OnMouseDownScaled;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point unscaledPt = UnscalePoint(e.Location, CanvasZoomFactor);
            OnMouseDownScaled?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, unscaledPt.X, unscaledPt.Y, e.Delta));
        }

        public event MouseEventHandler OnMouseUpScaled;

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Point unscaledPt = UnscalePoint(e.Location, CanvasZoomFactor);
            OnMouseUpScaled?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, unscaledPt.X, unscaledPt.Y, e.Delta));
        }

        public event MouseEventHandler OnMouseMoveScaled;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point unscaledPt = UnscalePoint(e.Location, CanvasZoomFactor);
            OnMouseMoveScaled?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, unscaledPt.X, unscaledPt.Y, e.Delta));
        }

        private Point UnscalePoint(Point scaledPoint, float zoomFactor)
        {
            //TODO unexpected behaviour here
            //if zoomFactor set to <= 0.5 approx.
            //the canvas flickers and tends to run far across the screen bounds
            //because unscaledPoint value becomes 
            Point unscaledPoint = Point.Empty;
            unscaledPoint.X = (int)Math.Round(scaledPoint.X / zoomFactor);
            unscaledPoint.Y = (int)Math.Round(scaledPoint.Y / zoomFactor);
            return unscaledPoint;
        }
    }
}
