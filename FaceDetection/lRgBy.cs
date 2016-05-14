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
        private Bitmap GambarSumber { set; get; }
        private Bitmap GambarOlah;
        private Double[,] L;
        private Double[,] RG;
        private Double[,] BY;
        private void initGambarOlah()
        {
            this.GambarOlah = new Bitmap(this.GambarSumber.Width, this.GambarSumber.Height);
            L = new Double[this.GambarSumber.Width, this.GambarSumber.Height];
            RG = new Double[this.GambarSumber.Width, this.GambarSumber.Height];
            BY = new Double[this.GambarSumber.Width, this.GambarSumber.Height];
        }
        public int lOperation(double x){
            return Convert.ToInt32(105*Math.Log(x+1,10));
        }
        private double I(double R, double G, double B)
        {
            return (lOperation(R) + lOperation(G) + lOperation(B) / 3);
        }

        private double Rg(double R, Double G)
        {
            return lOperation(R) - lOperation(G);
        }
        private double By(double R, Double G, Double B)
        {
            return lOperation(B) -((lOperation(G) + lOperation(R)) / 2);
        }
        public void convertToiRgBy(){
            initGambarOlah();
            for (int iterX = 0; iterX < this.GambarSumber.Width; iterX++)
            {
                for (int iterY = 0; iterY < this.GambarSumber.Height; iterY++)
                {
                    Color Warna = GambarSumber.GetPixel(iterX, iterY);
                    this.L[iterX, iterY] = I(Warna.R, Warna.G, Warna.B);
                    this.RG[iterX, iterY] = Rg(Warna.R, Warna.G);
                    this.BY[iterX, iterY] = By(Warna.R, Warna.G, Warna.B);
                }
            }
        }
    }
}
