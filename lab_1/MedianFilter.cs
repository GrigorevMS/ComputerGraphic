using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class MedianFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = 3;
            int radiusY = 3;

            List<int> R = new List<int>();
            List<int> G = new List<int>();
            List<int> B = new List<int>();

            for (int l = -radiusY; l <= radiusY; ++l)
                for (int k = -radiusX; k <= radiusX; ++k)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    R.Add(sourceImage.GetPixel(idX, idY).R);
                    G.Add(sourceImage.GetPixel(idX, idY).G);
                    B.Add(sourceImage.GetPixel(idX, idY).B);
                }
            R.Sort();
            G.Sort();
            B.Sort();

            return Color.FromArgb(R[R.Count / 2], G[G.Count / 2], B[B.Count / 2]); //выбор среднего значения
        }
    }
}
