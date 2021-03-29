using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class Reflector: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            int R_max = 0, G_max = 0, B_max = 0;
            for(int i = 0; i < sourceImage.Width; i++)
            {
                for(int j = 0; j < sourceImage.Height; j++)
                {
                    if (sourceImage.GetPixel(i, j).R > R_max)
                        R_max = sourceImage.GetPixel(i, j).R;
                    if (sourceImage.GetPixel(i, j).G > G_max)
                        G_max = sourceImage.GetPixel(i, j).G;
                    if (sourceImage.GetPixel(i, j).B > B_max)
                        B_max = sourceImage.GetPixel(i, j).B;
                }
            }
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int temp_R = Clamp(sourceImage.GetPixel(i, j).R * 255 / R_max, 0, 255);
                    int temp_G = Clamp(sourceImage.GetPixel(i, j).G * 255 / G_max, 0, 255);
                    int temp_B = Clamp(sourceImage.GetPixel(i, j).B * 255 / B_max, 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(temp_R, temp_G, temp_B));
                }
            }
            return resultImage;
        }
    }
}
