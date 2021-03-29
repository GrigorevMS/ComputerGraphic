using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class GrayScaleFilter: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int Intensity = (int)((float)0.299 * sourceColor.R + (float)0.587 * sourceColor.G + (float)0.144 * sourceColor.B);
            Intensity = Clamp(Intensity, 0, 255);
            Color resultColor = Color.FromArgb((int)Intensity, (int)Intensity, (int)Intensity);
            return resultColor;
        }
    }
}
