using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class Opening: Filters
    {
        Form2.MMCore mmCore;
        protected Opening() { }

        public Opening(Form2.MMCore mmCore)
        {
            this.mmCore = mmCore;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Erosion erosion = new Erosion(mmCore);
            Dilation dilation = new Dilation(mmCore);
            return dilation.processImage(erosion.processImage(sourceImage, worker), worker);
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
