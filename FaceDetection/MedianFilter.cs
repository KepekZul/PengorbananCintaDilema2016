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
        private int median;
        private int hitungMedian(int X, int Y, int[,] block)
        {
            List<int> data= new List<int>();
            for (int konter1=0; konter1 < X; konter1++)
            {
                for (int konter2 = 0; konter2 < Y; konter2++)
                {
                    data.Add(block[konter1,konter2]);
                }
            }
            data.Sort();
            return data[data.Count/2];
        }

        public void filterMatrix(int scale, int multiplier)
        {
            for (int konter1 = 0; konter1 < this.sizeX; konter1 += scale*multiplier)
            {
                for (int konter2 = 0; konter2 < this.sizeY; konter2 += scale*multiplier)
                {
                    int median = hitungMedian(konter1, konter2, this.Matrix);
                    for (int konter3 = 0; konter3 < konter1 + scale * multiplier; konter3++)
                    {
                        for (int konter4 = 0; konter4 < konter2 + scale * multiplier; konter4++)
                        {
                            Matrix[konter3, konter4] = median;
                        }
                    }
                }
            }
        }
    }
}
