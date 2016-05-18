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
        public static Bitmap Median(Bitmap source, int size)
        {
            Bitmap res = new Bitmap(source.Width, source.Height);

            Random random = new Random();
            int ApetureMin = -(size / 2);
            int ApetureMax = size / 2;
            for(int i = 0; i < res.Width; i++)
            {
                for(int j = 0; j < res.Height; j++)
                {
                    List<int> RValues = new List<int>();
                    List<int> GValues = new List<int>();
                    List<int> BValues = new List<int>();
                    for(int i2 = ApetureMin; i2 < ApetureMax; i2++)
                    {
                        int tempX = i + i2;
                        if(tempX>=0 && tempX < res.Width)
                        {
                            for(int j2 = ApetureMin; j2 < ApetureMax; j2++)
                            {
                                int tempY = j + j2;
                                if(tempY >= 0 && tempY < res.Height)
                                {
                                    Color tempColor = source.GetPixel(tempX, tempY);
                                    RValues.Add(tempColor.R);
                                    GValues.Add(tempColor.G);
                                    BValues.Add(tempColor.B);

                                }
                            }
                        }

                    }
                    RValues.Sort();
                    GValues.Sort();
                    BValues.Sort();
                    Color MedianPixel = Color.FromArgb(RValues[RValues.Count / 2], GValues[GValues.Count / 2], BValues[BValues.Count / 2]);
                    res.SetPixel(i, j, MedianPixel);
                }
            }
            return res;
        }
        /*private int[,] Matrix;
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
        }*/
    }
}
