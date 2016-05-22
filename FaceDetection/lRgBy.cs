using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FaceDetection
{
    class lRgBy
    {
        public Bitmap GambarSumber;
                
        public Tools.Raw[,] raw;
        
        public double lOperation(double x){
            return 105*(Math.Log(x+1,10));
        }
        private double I(double R, double G, double B)
        {
            return ((lOperation(R) + lOperation(G) + lOperation(B)) / 3);
        }

        private double Rg(double R, double I)
        {
            return (lOperation(R) - I); 
        }
        private double By(double B, double R, double I)
        {
            return lOperation(B) - ((I + lOperation(R)) / 2); ;
        }
        public void convertToiRgBy(){
            raw = new Tools.Raw[GambarSumber.Width, GambarSumber.Height];
            for (int iterX = 0; iterX < this.GambarSumber.Width; iterX++)
            {
                for (int iterY = 0; iterY < this.GambarSumber.Height; iterY++)
                {
                    Color Warna = GambarSumber.GetPixel(iterX, iterY);
                    raw[iterX, iterY].R = I(Warna.R, Warna.G, Warna.B);
                    raw[iterX, iterY].G = Rg(Warna.R, this.raw[iterX, iterY].R);
                    raw[iterX, iterY].B = By(Warna.B, Warna.R, this.raw[iterX, iterY].R);
                   
                }
            }
        }
    }
}
