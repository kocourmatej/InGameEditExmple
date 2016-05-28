using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    // Normalizace, centrování
    public static class GraphicsExt
    {
        public enum FillType
        {
            DontFill, Fill, Outline
        }

        public static void DrawCircle(Graphics g, Pen pen, float centerX, float centerY, float radius, FillType filled = FillType.DontFill)
        {
            if (filled == FillType.DontFill)
            {
                g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
            }
            else if (filled == FillType.Fill)
            {
                g.FillEllipse(new SolidBrush(pen.Color), centerX - radius, centerY - radius, radius + radius, radius + radius);
            }
            else
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(64, pen.Color)), centerX - radius, centerY - radius, radius + radius, radius + radius);
                g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
            }
        }
    }
}
