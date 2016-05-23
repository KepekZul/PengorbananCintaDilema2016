using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FaceDetection
{
    class Hole_Filling
    {
        private Bitmap GambarAsal;
        private int lebar;
        private int tinggi;
        public void setGambar(Bitmap gambar)
        {
            GambarAsal = gambar;
            lebar = gambar.Width;
            tinggi = gambar.Height;
        }
        private byte[,] mask = new byte[3, 3]
        {
            {0,1,0},
            {1,0,1},
            {0,1,0}
        };
        private byte[,] matrix;
        private void convertBitmapToByte()
        {
            ImageConverter converter = new ImageConverter();
            matrix = (byte[,]) converter.ConvertTo(this.GambarAsal, typeof(byte[]));
        }

       /*private bool cekMask(int x, int y)
        {
            if(this.matrix[x-1,y]==mask[1,0]||this.matrix[x,y-1]==mask[0,1]||this.matrix[x+1,y]==mask[2,1]||this.matrix[x,y+1]==mask[1,2]||)
        }*/

        public void doTheThings()
        {
            for (int counter1 = 1; counter1 < this.lebar-1; counter1++)
            {
                for (int counter2 = 1; counter2 < this.tinggi - 1; counter2++)
                {

                }
            }
        }
    }
}
