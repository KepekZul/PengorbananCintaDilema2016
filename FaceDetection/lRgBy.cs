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
        private Bitmap GambarOlah;
        private void initGambarOlah()
        {
            this.GambarOlah = new Bitmap(this.GambarSumber.Width, this.GambarSumber.Height);
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
        public Image convertToiRgBy(){
            initGambarOlah();
            for (int iterX = 0; iterX < this.GambarSumber.Width; iterX++)
            {
                for (int iterY = 0; iterY < this.GambarSumber.Height; iterY++)
                {

                }
            }
            return GambarOlah;
        }
    }
}
