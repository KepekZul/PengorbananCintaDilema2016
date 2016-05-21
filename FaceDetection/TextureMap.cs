using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging.Filters;

namespace FaceDetection
{

    
    class TextureMap
    {

        public static void Logger(String lines)
        {
            
        }
// public Bitmap imgSource { set; get;}
        

        private static double Hue(Color color)
        {
            //Console.WriteLine("fssdagaas");
            double tmp = (Math.Atan2(color.B/255,color.G/255)*(180/ Math.PI));
// Logger(tmp.ToString());
            return tmp;
        }

        private static double Saturation(Color color)
        {
            return Math.Sqrt(Math.Pow(color.G, 2) + Math.Pow(color.B, 2));
        }

       

        
        
        public static Bitmap huehue(Bitmap bitmap)
        {
            Bitmap bitText = new Bitmap(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    float a = color.GetHue();
                    int b = Convert.ToInt32(a);
                    Color colorC = Color.FromArgb(b,b,b);
                    bitText.SetPixel(i, j, colorC);
                }
            }
            return bitText;
        }

       
        public static Bitmap Process(Bitmap imgSource)
        {
            Bitmap bitmap = imgSource;
            double scale1 = (bitmap.Width + bitmap.Height) / 320;
            scale1 = Math.Round(scale1);
            int scale = Convert.ToInt32(scale1);
                        
            Bitmap bitMedian2 = FaceDetection.MedianFilter.Median1(bitmap, 4);


            Bitmap bitMedian1 = FaceDetection.MedianFilter.Median2(bitmap, 8);
            System.IO.StreamWriter file = new System.IO.StreamWriter("f:\\test.csv", true);
            System.IO.StreamWriter file1 = new System.IO.StreamWriter("f:\\test1.csv", true);
            System.IO.StreamWriter file2 = new System.IO.StreamWriter("f:\\test2.csv", true);
            Bitmap bitText = new Bitmap(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color colorA = bitMedian1.GetPixel(i, j);
                    Color colorB = bitmap.GetPixel(i, j);
                    int res = Math.Abs(colorA.R - colorB.R);
                    file.Write(res + ",");
                    file1.Write(colorB.G + ",");
                    file2.Write(colorB.B+ ",");
                    Color colorC = Color.FromArgb(res, colorB.G, colorB.B);
                    bitText.SetPixel(i, j, colorC);
                }
                file.WriteLine("");
                file1.WriteLine("");
                file2.WriteLine("");
            }
            /*
                Median Filter 2
            */
            
            file.Close();
            file1.Close();
            file2.Close();
            Bitmap bitMedian3 = FaceDetection.MedianFilter.Median2(bitText, 12);
            //return bitMedian3;
            
            int flag;

            
            Bitmap imgResult = new Bitmap(imgSource.Width, imgSource.Height);
            for (int iterX = 0; iterX < imgSource.Width; iterX++)
            {
                for (int iterY = 0; iterY < imgSource.Height; iterY++)
                {
                    flag = 0;
                    Color colora = bitMedian3.GetPixel(iterX, iterY);
                    Color color = bitmap.GetPixel(iterX, iterY);

                    if ( colora.R < 4.5 && 120 < color.GetHue() && color.GetHue() < 160 && 10 < Saturation(color) && Saturation(color) < 60)
                    {
                        flag = 1;
                    }
                    if (colora.R < 4.5 && 150 < color.GetHue() && color.GetHue() < 180 && Saturation(color) > 20 && Saturation(color) < 80)
                    {
                        flag = 1;
                    }
                    if (flag == 1)
                    {
                        //Console.Write("dasfdfs");
                        color = Color.FromArgb(255, 255, 255);
                    }
                    else{
                        color = Color.FromArgb(0, 0, 0);
                    }
                    imgResult.SetPixel(iterX, iterY, color);
                }
            }

            return imgResult;
            
        }

    }
}
