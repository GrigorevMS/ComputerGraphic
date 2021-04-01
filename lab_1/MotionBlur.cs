using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class MotionBlur : MatrixFilter
    {
       public MotionBlur()
        {
            int sizeX = 9;
            int sizeY = 9;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                {
                    if (i == j)
                        kernel[i, j] = 1.0f / (float)(sizeY);
                    else
                        kernel[i, j] = 0.0f;
                }
        }
    }
}
