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

        public float ZoomStep { get; set; } = ZOOM_STEP;

        public SmoothingMode CanvasSmoothing { get; set; } = SmoothingMode.None;

        public Size CanvasSizeOriginal { get; private set; }

        public DrawCanvas()
        {
            InitializeComponent();
            DoubleBuffered = true;
            CanvasSizeOriginal = Size;//for VS Constructor
        }

        public void SetSize(Size size)
        {
            CanvasSizeOriginal = size;
            this.Size = size;
        }

        public void CenterParent()
        {
            int locY = (Parent.ClientSize.Height - Height) / 2;
            int locX = (Parent.ClientSize.Width - Width) / 2;
            Location = new Point(locX, locY);
        }

        public void ZoomIn()
        {
            CanvasZoomFactor += ZoomStep;
            Invalidate();
        }

        public void ZoomOut()
        {
            if (CanvasZoomFactor <= ZoomStep)
            {
                return;
            }
            CanvasZoomFactor -= ZoomStep;
            Invalidate();
        }

        public void ZoomReset()
        {
            CanvasZoomFactor = 1.0F;
            Invalidate();
            CenterParent();
        }

        public Bitmap GetBitmap()
        {
            ZoomReset();
            Bitmap btmp = new Bitmap(Width, Height, CreateGraphics());
            DrawToBitmap(btmp, new Rectangle(0, 0, Width, Height));
            return btmp;
        }

        public event PaintEventHandler ShapesDrawRequest;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = CanvasSmoothing;
            e.Graphics.ScaleTransform(CanvasZoomFactor, CanvasZoomFactor);
            ShapesDrawRequest?.Invoke(this, e);
            this.Size = new Size((int)(CanvasSizeOriginal.Width * CanvasZoomFactor), (int)(CanvasSizeOriginal.Height * CanvasZoomFactor));
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
            //здесь проблема
            //при малых zoomFactor (<= 0.5 примерно)
            //при перемещении дрожит изображение и даже уезжает далеко за пределы экрана
            //потому что координаты принимают надекватно большие значения
            Point unscaledPoint = Point.Empty;
            unscaledPoint.X = (int)Math.Round(scaledPoint.X / zoomFactor);
            unscaledPoint.Y = (int)Math.Round(scaledPoint.Y / zoomFactor);
            return unscaledPoint;
        }
    }
}
