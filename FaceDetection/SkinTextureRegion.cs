using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging.Filters;

namespace FaceDetection
{
    class SkinTextureRegion
    {

        public Bitmap imgSource { set; get;}
        public Bitmap imgTexture;
        public Bitmap imgResult;

        private double Hue(Color color)
        {
            return Math.Atan2(color.G, color.B)*((double)180 /Math.PI);
        }

        private double Saturation(Color color)
        {
            return Math.Sqrt(Math.Pow(color.G, 2) + Math.Pow(color.B, 2));
        }

       

        

        private Bitmap textureAmplitude(Bitmap bitmap)
        {
            /*
               Process Median Filtering
            */
            Bitmap bitMedian1= bitmap;
            Bitmap bitText = new Bitmap(bitmap.Width, bitmap.Height);
            for(int i=0; i < bitmap.Width; i++)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {
                    Color colorA = bitmap.GetPixel(i, j);
                    Color colorB = bitMedian1.GetPixel(i, j);
                    int res = Math.Abs(colorA.R - colorB.R);
                    Color colorC = Color.FromArgb(res, 0, 0);
                    bitText.SetPixel(i, j, colorC);
                }
            }
            /*
                Median Filter 2
            */

            Bitmap bitMedian2 = bitText;
            return bitMedian2;

        }

        private double MAD(Color color)
        {

            return 0;
        }

        private Bitmap Process()
        {
            int flag;
            this.imgResult = new Bitmap(imgSource.Width, imgSource.Height);
            for (int iterX = 0; iterX < this.imgSource.Width; iterX++)
            {
                for (int iterY = 0; iterY < this.imgSource.Height; iterY++)
                {
                    flag = 0;
                    Color color = this.imgSource.GetPixel(iterX, iterY);
                    Color colorb = imgTexture.GetPixel(iterX, iterY);
                    if ( colorb.R < 4.5 && 120 < Hue(color) && Hue(color) < 160 && 10 < Saturation(color) && Saturation(color) < 60)
                    {
                        flag = 1;
                    }
                    if (colorb.R < 4.5 && 150 < Hue(color) && Hue(color) < 180 && Saturation(color) > 20 && Saturation(color) < 80)
                    {
                        flag = 1;
                    }
                    if (flag == 1)
                    {
                        color = Color.FromArgb(1, 0, 0);
                    }
                    else{
                        color = Color.FromArgb(0, 0, 0);
                    }
                    this.imgResult.SetPixel(iterX, iterY, color);
                }
            }
            return this.imgResult;

        }

    }
}
