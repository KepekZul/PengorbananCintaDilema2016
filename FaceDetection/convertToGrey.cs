using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace FaceDetection
{
    class convertToGrey
    {
        public Bitmap convert(Bitmap gambar)
        {
            Color warnaAsli;
            Color warnaBaru;
            Bitmap gambarBitmap = new Bitmap(gambar);
            Bitmap gambarBaru = new Bitmap(gambarBitmap.Width, gambarBitmap.Height);
            for (int i = 0; i < gambarBitmap.Width; i++)
            {
                for (int j = 0; j < gambarBitmap.Height; j++)
                {
                    warnaAsli = gambarBitmap.GetPixel(i, j);
                    warnaBaru = Color.FromArgb(warnaAsli.G, warnaAsli.G, warnaAsli.G);
                    gambarBaru.SetPixel(i, j, warnaBaru);
                }
            }
            return gambarBaru;
        }
        public Bitmap multiply(Bitmap a, Bitmap mask)
        {
            Color warnaBaru;
            Bitmap gambarBitmap = new Bitmap(a);
            warnaBaru = Color.FromArgb(0, 0, 0);
            for (int i = 0; i < gambarBitmap.Width; i++)
            {
                for (int j = 0; j < gambarBitmap.Height; j++)
                {
                    if (mask.GetPixel(i, j) == warnaBaru)
                    {
                        gambarBitmap.SetPixel(i, j, warnaBaru);
                    }
                }
            }
            return gambarBitmap;
        }
    }
}
