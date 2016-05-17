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
        public Bitmap imgResult;

        private double Hue(Color color)
        {
            return Math.Atan2(color.G, color.B)*((double)180 /Math.PI);
        }

        private double Saturation(Color color)
        {
            return Math.Sqrt(Math.Pow(color.G, 2) + Math.Pow(color.B, 2));
        }

        private double MedianFilter(Color color)
        {
            return 0;
        }

        

        private Bitmap Process()
        {
            Median median = new Median();
            median.ApplyInPlace(image);
            int flag;
            this.imgResult = new Bitmap(imgSource.Width, imgSource.Height);
            for (int iterX = 0; iterX < this.imgSource.Width; iterX++)
            {
                for (int iterY = 0; iterY < this.imgSource.Height; iterY++)
                {
                    flag = 0;
                    Color color = this.imgSource.GetPixel(iterX, iterY);
                    if (this.MedianFilter(color) < 4.5 && 120 < Hue(color) && Hue(color) < 160 && 10 < Saturation(color) && Saturation(color) < 60)
                    {
                        flag = 1;
                    }
                    if (this.MedianFilter(color) < 4.5 && 150 < Hue(color) && Hue(color) < 180 && Saturation(color) > 20 && Saturation(color) < 80)
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
