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
        public List<KeyValuePair<int, int>> BoundaryLine;
        private byte[,] matrix;
        private int lebar;
        private int tinggi;
        public BoundaryTracing(Bitmap sumber)
        {
            ImageConverter converter = new ImageConverter();
            matrix = (byte[,])converter.ConvertTo(sumber, typeof(byte[]));
            this.lebar = sumber.Width;
            this.tinggi = sumber.Height;
        }
        private void recursiveFloodHere(int x, int y)
        {

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
                }
                else if (spot == 2)//recurs ke nex
                {
                    this.matrix[tf[i + 1, 0], tf[i + 1, 1]] = 5;
                    recursiveBoundaryHere(tf[i + 1, 0], tf[i + 1, 1]);
                }
                else
                {
                    return;
                }
            }
        }
        public void traceBoundary()
        {
            for (int x = 0; x <this.lebar ; x++)
            {
                for (int y = 0; y <this.tinggi ; y++)
                {
                    if (this.matrix[x,y]==255)
                    {
                        recursiveBoundaryHere(x, y);
                    }
                }
            }
        }
    }
}