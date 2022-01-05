using System.Collections.Generic;
using System.Linq;
using System.Drawing.Drawing2D;

namespace SimplePaint
{
    /*
     * Stores DashStyle and corresponding name collations. Used to fill a combobox content 
     * and to transform the combobox.selectedvalue into the matching DashStyle.
     * 
     * © Alexander V. Korostelin, SibSUTIS, Novosibirsk 2021
     */
    public static class DashStyles
    {
        private static readonly List<(string, DashStyle)> dshstyles = new List<(string, DashStyle)>();

        static DashStyles()
        {
            dshstyles.Add(("------ Сплошной", DashStyle.Solid));
            dshstyles.Add(("- - -  Пунктир", DashStyle.Dash));
            dshstyles.Add(("...... Точки", DashStyle.Dot));
            dshstyles.Add(("-.-.-. Тире-точка", DashStyle.DashDot));
            dshstyles.Add(("-..-.. Тире-двойная точка", DashStyle.DashDotDot));
        }

        public static string[] GetReadableNames()
        {
            return dshstyles.Select(x => x.Item1).ToArray();
        }

        public static DashStyle GetDashStyleByName(string readablename)
        {
            try
            {
                return dshstyles.Where(x => x.Item1.Equals(readablename)).Select(x => x.Item2).Single();
            }
            catch
            {
                return DashStyle.Solid;
            }
        }
    }
}
