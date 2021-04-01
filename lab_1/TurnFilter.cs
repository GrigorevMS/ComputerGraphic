using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class TurnFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            {
                int x0 = (int)(sourceImage.Width / 2), y0 = (int)(sourceImage.Height / 2);
                double w = Math.PI / 4.0;
                int _x = (int)((x - x0) * Math.Cos(w) - (y - y0) * Math.Sin(w) + x0);
                int _y = (int)((x - x0) * Math.Sin(w) + (y - y0) * Math.Cos(w) + y0);

                if ((_x < sourceImage.Width - 1) && (_y < sourceImage.Height - 1) && (_x > 0) && (_y > 0))
                {
                    Color resultColor = sourceImage.GetPixel(_x, _y);
                    return resultColor;
                }
                return Color.Transparent;
            }
        }
    }
}
