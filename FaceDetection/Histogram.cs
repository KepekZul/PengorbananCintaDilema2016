using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection
{
    class Histogram
    {
        public static Bitmap CalculateHistogram(Bitmap gambarBitmap)
        {
            int[,] temp = new int[256, 1];
            int[,] temp1 = new int[256, 1];
            int nilaiPixel;

            for (int i = 0; i < gambarBitmap.Width; i++)
            {
                for (int j = 0; j < gambarBitmap.Height; j++)
                {
                    nilaiPixel = gambarBitmap.GetPixel(i, j).R;
                    if (nilaiPixel != 0)
                    {
                        temp[nilaiPixel, 0] = temp[nilaiPixel, 0] + 1;
                    }
                }
            }
            temp1[0, 0] = temp[0, 0];
            for (int i = 1; i <= 255; i++)
            {
                temp1[i, 0] = temp1[i - 1, 0] + temp[i, 0];
            }
            int total = temp1[255, 0];

            for (int i = 0; i <= 255; i++)
            {
                temp1[i, 0] = (int)((float)temp1[i, 0] / (float)total * 255);
            }
            Bitmap gambarBaru = new Bitmap(gambarBitmap.Width, gambarBitmap.Height);
            for (int i = 0; i < gambarBitmap.Width; i++)
            {
                for (int j = 0; j < gambarBitmap.Height; j++)
                {
                    Color warnaAsli = gambarBitmap.GetPixel(i, j);
                    if (warnaAsli != Color.FromArgb(0, 0, 0))
                    {
                        int x = temp1[warnaAsli.R, 0];
                        Color warnaBaru = Color.FromArgb(x, x, x);
                        gambarBaru.SetPixel(i, j, warnaBaru);
                    }
                    else
                    {
                        gambarBaru.SetPixel(i, j, warnaAsli);

                    }
                }
            }
            return gambarBaru;
        }
    }
}
