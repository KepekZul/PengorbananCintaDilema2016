using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FaceDetection
{
    class MedianFilter
    {
        private int[,] Matrix;
        private int sizeX;
        private int sizeY;
        private long  hitungMean(int x1, int x2, int y1, int y2){
            long hasil;
            for (int konter = x1; konter < x2; konter++)
            {
                for (int konter2 = x2; konter2 < x2; konter2++)
                {
                    hasil=
                }
            }
            return hasil;
        }
        public void setMatrix(int x, int y, int[,] source)
        {
            this.Matrix = new int[x, y];
            this.sizeX = x;
            this.sizeY = y;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    this.Matrix[i, j] = source[i, j];
                }
            }
        }
        public void filterImage(int scale)
        {
            int median=0;
            for (int konter = 0; konter <this.sizeX; konter += 4*scale)
            {
                for (int konter2 = 0; konter2 < this.sizeY; konter2 += 4 * scale)
                {
                    median = (int) hitungMean(konter, konter+(4*scale), konter2, konter2+(4*scale));
                    median = median / (this.sizeX * this.sizeY);
                }
            }
            

        }
    }
}
