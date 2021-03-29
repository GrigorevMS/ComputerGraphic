using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_1
{
    class Erosion: Filters
    {
        protected Form2.MMCore mmCore;

        protected Erosion() { }

        public Erosion(Form2.MMCore mmCore)
        {
            this.mmCore = mmCore;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage);
            int halfSize = mmCore.coreSize / 2;
            for (int x = halfSize; x < sourceImage.Width - halfSize; x++)
            {
                worker.ReportProgress((int)((float)x / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int y = halfSize; y < sourceImage.Height - halfSize; y++)
                {
                    Color minIntencity = calculateNewPixelColor(sourceImage, x, y);
                    int min_x = x, min_y = y;
                    for (int i = -halfSize; i <= halfSize; i++)
                    {
                        for (int j = -halfSize; j <= halfSize; j++)
                        {
                            Color curIntencity = calculateNewPixelColor(sourceImage, x + i, y + j);
                            if (mmCore.core[i + halfSize, j + halfSize] > 0.5F && curIntencity.R < minIntencity.R)
                            {
                                min_x = x + i;
                                min_y = y + j;
                                minIntencity = curIntencity;
                            }
                        }
                    }
                    resultImage.SetPixel(x, y, sourceImage.GetPixel(min_x, min_y));
                }
            }
            return resultImage;
        }

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

