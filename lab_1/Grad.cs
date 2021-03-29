using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class Grad : Filters
    {
        Form2.MMCore mmCore;
        protected Grad() { }
        public Grad(Form2.MMCore mmCore)
        {
            this.mmCore = mmCore;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Dilation dilation = new Dilation(mmCore);
            Erosion erosion = new Erosion(mmCore);
            Bitmap resultImage = new Bitmap(sourceImage);
            Bitmap dilationImage = dilation.processImage(sourceImage, worker);
            Bitmap erosionImage = erosion.processImage(sourceImage, worker);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color a_color = dilationImage.GetPixel(i, j);
                    Color b_color = erosionImage.GetPixel(i, j);
                    int R = Clamp(a_color.R - b_color.R, 0, 255);
                    int G = Clamp(a_color.G - b_color.G, 0, 255);
                    int B = Clamp(a_color.B - b_color.B, 0, 255);
                    resultImage.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            return resultImage;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
