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
        public Image GambarAsli { set; get; }
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

            return this.GambarAsli;
        }
    }
}
