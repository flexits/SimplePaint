using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimplePaint
{
    /*
     * The control represents a scalable drawing area
     * 
     * © Alexander V. Korostelin, SibSUTIS, Novosibirsk 2021
     */
    public partial class DrawCanvas : UserControl
    {
        private const float DEFAULT_ZOOM_FACTOR = 1.0F;                     //default scale is 100%
        private const float ZOOM_STEP = 0.1F;                               //scale modification step is 10%

        public float ZoomFactor { get; set; } = DEFAULT_ZOOM_FACTOR;        //this area scale
        public Size SizeOriginal { get; private set; }                      //original size without zoom 
        public SmoothingMode Smoothing { get; set; } = SmoothingMode.None;  //smoothing mode of this.Graphics

        public event PaintEventHandler ShapesDrawRequest;                   //invoked on this.Paint; may be used to draw objects in e.Graphics
        public event MouseEventHandler OnMouseDownScaled;                   //overrided mouse events provide e.Location re-calculated without scaling
        public event MouseEventHandler OnMouseUpScaled;
        public event MouseEventHandler OnMouseMoveScaled;

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

        public Graphics GetGraphics()                   //return scaled this.Graphics
        {
            Graphics gr = CreateGraphics();
            gr.ScaleTransform(ZoomFactor, ZoomFactor);
            return gr;
        }

        public Bitmap GetBitmap()                       //draw control's contents into bitmap
        {
            ZoomReset();
            Bitmap btmp = new Bitmap(Width, Height, CreateGraphics());
            DrawToBitmap(btmp, new Rectangle(0, 0, Width, Height));
            return btmp;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = Smoothing;
            e.Graphics.ScaleTransform(ZoomFactor, ZoomFactor);
            ShapesDrawRequest?.Invoke(this, e);
            Size = new Size((int)(SizeOriginal.Width * ZoomFactor), (int)(SizeOriginal.Height * ZoomFactor));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point unscaledPt = PointMath.UnscalePoint(e.Location, ZoomFactor);
            OnMouseDownScaled?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, unscaledPt.X, unscaledPt.Y, e.Delta));
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Point unscaledPt = PointMath.UnscalePoint(e.Location, ZoomFactor);
            OnMouseUpScaled?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, unscaledPt.X, unscaledPt.Y, e.Delta));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point unscaledPt = PointMath.UnscalePoint(e.Location, ZoomFactor);
            OnMouseMoveScaled?.Invoke(this, new MouseEventArgs(e.Button, e.Clicks, unscaledPt.X, unscaledPt.Y, e.Delta));
        }
    }
}
