using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection
{
    class Thresholding
    {
        public static Bitmap Threshold(Bitmap bitmap, int val1=0, int val2=255)
        {
            Bitmap gambar = new Bitmap(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    if (val1 < color.R && color.R < val2) //Interval value
                    {
                        gambar.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        gambar.SetPixel(i, j, Color.Black);
                    }
                }
            }
            return gambar;
        }
    }
}
