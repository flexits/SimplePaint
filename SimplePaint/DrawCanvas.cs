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
        public float CanvasZoomFactor { get; private set; } = 1.0F;

        public float ZoomStep { get; set; } = 0.1F;

        public SmoothingMode CanvasSmoothing { get; set; } = SmoothingMode.None;

        public DrawCanvas()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Width = canvasSizeOriginal.Width;
            Height = canvasSizeOriginal.Height;
        }

        public Size canvasSizeOriginal { get; set; }

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
            Bitmap btmp = new Bitmap(this.Width, this.Height, CreateGraphics());
            Rectangle cr = this.ClientRectangle;
            cr = new Rectangle(0, 0, this.Width, this.Height);
            this.DrawToBitmap(btmp, cr);
            return btmp;
        }

        public event PaintEventHandler ShapesDrawRequest;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = CanvasSmoothing;
            e.Graphics.ScaleTransform(CanvasZoomFactor, CanvasZoomFactor);
            ShapesDrawRequest?.Invoke(this, e);
            this.Size = new Size((int)(canvasSizeOriginal.Width * CanvasZoomFactor), (int)(canvasSizeOriginal.Height * CanvasZoomFactor));
            //CenterParent();
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
            //координаты очень быстро становятся неадекватными,
            //из-за этого при перемещении дрожит изображение и даже уезжает далеко за пределы экрана
            Point unscaledPoint = Point.Empty;
            unscaledPoint.X = (int)Math.Round(scaledPoint.X / zoomFactor);
            unscaledPoint.Y = (int)Math.Round(scaledPoint.Y / zoomFactor);
            return unscaledPoint;
        }
    }
}
