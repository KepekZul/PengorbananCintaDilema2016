using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection
{
    class Dilation
    {
        public Bitmap Dilate(Bitmap source)
        {
            Bitmap temp = new Bitmap(source.Width, source.Height);

            BitmapData sourceData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData destData = source.LockBits(new Rectangle(0, 0, temp.Width, temp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte[,] sElement = new byte[5, 5]
            {
                {0,0,1,0,0},
                {0,1,1,1,0},
                {1,1,1,1,1},
                {0,1,1,1,0},
                {0,0,1,0,0}
            };

            int size = 5;
            byte max, clrValue;
            int radius = size / 2;
            

            unsafe
            {
                int ir, jr;
                for (int j=radius; j<destData.Height - radius; j++)
                {
                    byte* ptr = (byte*)sourceData.Scan0 + (j * sourceData.Stride);
                    byte* dstPtr = (byte*)destData.Scan0 + (j * sourceData.Stride);

                    for(int i= radius; i<destData.Width - radius; i++)
                    {
                        max = 0;
                        clrValue = 0;

                        for(int ej = 0; ej < 5; ej++)
                        {
                            ir = ej - radius;
                            byte* tempPtr = (byte*)sourceData.Scan0 + ((j + ir) * sourceData.Stride);
                            for(int ei = 0; ei < 5; ei++)
                            {
                                jr = ei - radius;
                                clrValue = (byte)((tempPtr[i * 3 + jr] +
                                tempPtr[i * 3 + jr + 1] + tempPtr[i * 3 + jr + 2]) / 3);
                                if (max < clrValue)
                                {
                                    if (sElement[ej, ei] != 0)
                                        max = clrValue;
                                }
                                 
                            }

                        }

                        dstPtr[0] = dstPtr[1] = dstPtr[2] = max;
                        ptr += 3;
                        dstPtr += 3;
                    }
                }
            }

            source.UnlockBits(sourceData);
            temp.UnlockBits(destData);

            return temp;

        }
    }
}
