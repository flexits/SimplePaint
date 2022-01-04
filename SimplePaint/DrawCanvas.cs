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

        public float ZoomFactor { get; set; } = DEFAULT_ZOOM_FACTOR;

        public SmoothingMode Smoothing { get; set; } = SmoothingMode.None;

        public Size SizeOriginal { get; private set; }

        public event PaintEventHandler ShapesDrawRequest;

        public DrawCanvas()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SizeOriginal = Size; //needed for VS Constructor
        }

        public void SetSize(Size size)
        {
            SizeOriginal = size;
            this.Size = size;
        }

        public void ZoomIn()
        {
            ZoomFactor += ZOOM_STEP;
            Invalidate();
        }

        public void ZoomOut()
        {
            if (ZoomFactor <= ZOOM_STEP)
            {
                return;
            }
            ZoomFactor -= ZOOM_STEP;
            Invalidate();
        }

        public void ZoomReset()
        {
            ZoomFactor = 1.0F;
            Invalidate();
        }

        public Graphics GetGraphics()
        {
            Graphics gr = CreateGraphics();
            gr.ScaleTransform(ZoomFactor, ZoomFactor);
            return gr;
        }

        public Bitmap GetBitmap()
        {
            ZoomReset();
            Bitmap btmp = new Bitmap(Width, Height, CreateGraphics());
            DrawToBitmap(btmp, new Rectangle(0, 0, Width, Height));
            return btmp;
        }

        /*public void CenterParent()
        {
            int locY = (Parent.Height - Height) / 2;
            int locX = (Parent.Width - Width) / 2;
            Location = new Point(locX, locY);
        }*/

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = Smoothing;
            e.Graphics.ScaleTransform(ZoomFactor, ZoomFactor);
            ShapesDrawRequest?.Invoke(this, e);
            Size = new Size((int)(SizeOriginal.Width * ZoomFactor), (int)(SizeOriginal.Height * ZoomFactor));
        }

        public event MouseEventHandler OnMouseDownScaled;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point unscaledPt = PointMath.UnscalePoint(e.Location, ZoomFactor);
            OnMouseDownScaled?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, unscaledPt.X, unscaledPt.Y, e.Delta));
        }

        public event MouseEventHandler OnMouseUpScaled;

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Point unscaledPt = PointMath.UnscalePoint(e.Location, ZoomFactor);
            OnMouseUpScaled?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, unscaledPt.X, unscaledPt.Y, e.Delta));
        }

        public event MouseEventHandler OnMouseMoveScaled;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point unscaledPt = PointMath.UnscalePoint(e.Location, ZoomFactor);
            OnMouseMoveScaled?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, unscaledPt.X, unscaledPt.Y, e.Delta));
        }
    }
}
