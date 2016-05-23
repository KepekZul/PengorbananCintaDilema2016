using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FaceDetection
{
    class BoundaryTracing
    {
        private byte[,] matrix;
        private int lebar;
        private int tinggi;
        public Queue<KeyValuePair<int,int>> holes = new Queue<KeyValuePair<int,int>>();
        public BoundaryTracing(Bitmap sumber)
        {
            ImageConverter converter = new ImageConverter();
            matrix = (byte[,])converter.ConvertTo(sumber, typeof(byte[]));
            this.lebar = sumber.Width;
            this.tinggi = sumber.Height;
        }
        private void BFSflood(int x, int y)
        {
            Queue<KeyValuePair<int, int>> kueue = new Queue<KeyValuePair<int, int>>();
            kueue.Enqueue(new KeyValuePair<int, int>(x, y));
            while (kueue.Count != 0)
            {
                KeyValuePair<int, int> temp;
                temp = kueue.Dequeue();
                int x2=temp.Key, y2=temp.Value;
                if (this.matrix[temp.Key, temp.Value] != 5)
                {
                    if (this.matrix[x2, y2] == 0)
                    {
                        this.holes.Enqueue(temp);
                    }
                    if (this.matrix[x2, y2] != 5)
                    {
                        this.matrix[x2, y2] = 5;
                        if (x2 - 1 > 0)
                        {
                            if (y2 - 1 > 0)
                            {
                                if (this.matrix[x2 - 1, y2 - 1] != 5)
                                {
                                    kueue.Enqueue(new KeyValuePair<int, int>(x2 - 1, y2 - 1));
                                }
                            }
                            if (y2 + 1 < this.tinggi)
                            {
                                if (this.matrix[x2 - 1, y2 + 1] != 5)
                                {
                                    kueue.Enqueue(new KeyValuePair<int, int>(x2 - 1, y2 + 1));
                                }
                            }
                            if (this.matrix[x2 - 1, y2] != 5)
                            {
                                kueue.Enqueue(new KeyValuePair<int, int>(x2 - 1, y2));
                            }
                        }
                        if (x2 + 1 < this.lebar)
                        {
                            if (y2 - 1 > 0)
                            {
                                if (this.matrix[x2 + 1, y2 - 1] != 5)
                                {
                                    kueue.Enqueue(new KeyValuePair<int, int>(x2 + 1, y2 - 1));
                                }
                            }
                            if (y2 + 1 < this.tinggi)
                            {
                                if (this.matrix[x2 + 1, y2 + 1] != 5)
                                {
                                    kueue.Enqueue(new KeyValuePair<int, int>(x2 + 1, y2 + 1));
                                }
                            }
                            if (this.matrix[x2 + 1, y2] != 5)
                            {
                                kueue.Enqueue(new KeyValuePair<int, int>(x2 + 1, y2));
                            }
                        }
                        if (y2 - 1 > 0)
                        {
                            if (this.matrix[x2, y2 - 1] != 5)
                            {
                                kueue.Enqueue(new KeyValuePair<int, int>(x2, y2-1));
                            }
                        }
                        if (y2 + 1 < this.tinggi)
                        {
                            if (this.matrix[x2, y2 + 1] != 5)
                            {
                                kueue.Enqueue(new KeyValuePair<int, int>(x2, y2 + 1));
                            }
                        }
                    }
                    this.matrix[x2, y2] = 5;
                }
            }
            return;
        }

        private int cekBeda(int pre, int nex)
        {
            if (pre == 255)
            {
                return 1;
            }
            else if (nex == 255)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        private void recursiveBoundaryHere(int x, int y)
        {
            int prev; int next;
            int[,] tf = new int[9, 2]
            {
                {0,-1},
                {1,-1},
                {1,0},
                {1,1},
                {0,1},
                {-1,1},
                {-1,0},
                {-1,-1},
                {0,-1}
            };
            for(int i=0; i<8; i++)
            {
                prev = this.matrix[tf[i, 0], tf[i, 1]];
                next = this.matrix[tf[i + 1, 0], tf[i + 1, 1]];
                int spot=cekBeda(prev,next);
                if(spot==1)//recurs ke pre
                {
                    this.matrix[tf[i, 0], tf[i, 1]] = 5;
                    recursiveBoundaryHere(tf[i, 0], tf[i, 1]);
                    break;
                }
                else if (spot == 2)//recurs ke nex
                {
                    this.matrix[tf[i + 1, 0], tf[i + 1, 1]] = 5;
                    recursiveBoundaryHere(tf[i + 1, 0], tf[i + 1, 1]);
                    break;
                }
                else
                {
                    return;
                }
            }
            return;
        }
        public void traceBoundary()
        {
            for (int x = 0; x <this.lebar ; x++)
            {
                for (int y = 0; y <this.tinggi ; y++)
                {
                    if (this.matrix[x,y]==255)
                    {
                        this.matrix[x, y] = 5;
                        recursiveBoundaryHere(x, y);
                    }
                }
            }
        }
    }
}