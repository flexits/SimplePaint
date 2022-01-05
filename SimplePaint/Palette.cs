using System.Drawing;

namespace SimplePaint
{
    /*
     * Palette object incapsulates user settings for drawing tools
     * by holding corresponding pens and brushes.
     *
     * © Alexander V. Korostelin, SibSUTIS, Novosibirsk 2021
     */

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
}
