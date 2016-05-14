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
        public Bitmap GambarSumber { set; get; }
        public Bitmap GambarOlah;
        public Double[,] L;
        public Double[,] RG;
        public Double[,] BY;
        private void initGambarOlah()
        {
            this.GambarOlah = new Bitmap(this.GambarSumber.Width, this.GambarSumber.Height);
            int Width = this.GambarSumber.Width;
            int Height = this.GambarSumber.Height;
            L = new Double[Width, Height];
            RG = new Double[Width, Height];
            BY = new Double[Width, Height];
        }
        public int lOperation(double x){
            return Convert.ToInt32(105*(Math.Log(x+1,10)));
        }
        private double I(double R, double G, double B)
        {
            return ((lOperation(R) + lOperation(G) + lOperation(B)) / 3);
        }

        private double Rg(double R, Double G)
        {
            int hasil =Convert.ToInt32(lOperation(R) - lOperation(G)>0);
            return (hasil>0?hasil:0 );
        }
        private double By(double R, Double G, Double B)
        {
            int hasil= lOperation(B) -((lOperation(G) + lOperation(R)) / 2);
            return (hasil > 0 ? hasil : 0);
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
                    Color WarnaIRgBy = Color.FromArgb( Convert.ToInt32(this.L[iterX,iterY]), Convert.ToInt32( this.RG[iterX,iterY]), Convert.ToInt32( this.BY[iterX,iterY]));
                    this.GambarOlah.SetPixel(iterX, iterY, WarnaIRgBy);
                }
            }
        }
    }
}
