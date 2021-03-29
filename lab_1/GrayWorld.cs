using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class GrayWorld: Filters
    {


        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage);
            int R_r = 0, G_r = 0, B_r = 0, Avg;
            {
                for (int i = 0; i < sourceImage.Width; i++)
                {
                    for (int j = 0; j < sourceImage.Height; j++)
                    {
                        R_r += sourceImage.GetPixel(i, j).R;
                        G_r += sourceImage.GetPixel(i, j).G;
                        B_r += sourceImage.GetPixel(i, j).B;
                    }
                }
                R_r = Clamp(R_r / (sourceImage.Height * sourceImage.Width), 0, 255);
                G_r = Clamp(G_r / (sourceImage.Height * sourceImage.Width), 0, 255);
                B_r = Clamp(B_r / (sourceImage.Height * sourceImage.Width), 0, 255);
                Avg = Clamp((R_r + G_r + B_r) / 3, 0, 255);
            }
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int resR = Clamp(sourceImage.GetPixel(i, j).R * Avg / R_r, 0, 255);
                    int resG = Clamp(sourceImage.GetPixel(i, j).G * Avg / G_r, 0, 255);
                    int resB = Clamp(sourceImage.GetPixel(i, j).B * Avg / B_r, 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(resR, resG, resB));
                }
            }
            return resultImage;
        }
    }
}
