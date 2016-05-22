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


        private static double Hue(double x, double y)
        {
            //Console.WriteLine("fssdagaas");
            double tmp = (Math.Atan2(x, y) * (180 / Math.PI));
            // Logger(tmp.ToString());
            return tmp;
        }

        private static double Saturation(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }





        public static void huehue(Tools.Raw[,] rew, int Width, int Height)
        {
            Tools.Raw[,] riw = new Tools.Raw[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    riw[i, j].R = Hue(rew[i, j].G, rew[i, j].B);
                    riw[i, j].G = 0;
                    riw[i, j].B = 0;
                }
            }
            Tools.Writer(riw, Width, Height);
        }

        public static Tools.Raw[,] Copy(Tools.Raw[,] rew, int Width, int Height)
        {
            Tools.Raw[,] riw = new Tools.Raw[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    riw[i, j] = rew[i, j];
                }
            }
            return riw;
            //Tools.Writer(riw, Width, Height);
        }


        public static Tools.Raw[,] Process(Tools.Raw[,] raw, int Width, int Height)
        {

            Tools.Raw[,] raw2 = FaceDetection.MedianFilter.Median2(raw, Width, Height, 4);


            Tools.Raw[,] raw1 = Copy(raw2, Width, Height);
            raw1 = FaceDetection.MedianFilter.Median1(raw1, Width, Height, 8);


            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    double resz = Math.Abs(raw1[i, j].R - raw[i, j].R);
                    raw1[i, j].R = resz;
                }

            }

            raw1 = FaceDetection.MedianFilter.Median1(raw1, Width, Height, 12);
            //Tools.Writer(raw, Width, Height);
            //Tools.Writer(raw1, Width, Height);

            int flag;

            Tools.Raw[,] res = new Tools.Raw[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    flag = 0;


                    if (raw1[i, j].R < 4.5 && 120 < Hue(raw2[i, j].G, raw2[i, j].B) && Hue(raw2[i, j].G, raw2[i, j].B) < 160 && 10 < Saturation(raw2[i, j].G, raw2[i, j].B) && Saturation(raw2[i, j].G, raw2[i, j].B) < 60)
                    {
                        flag = 1;
                    }
                    if (raw1[i, j].R < 4.5 && 150 < Hue(raw2[i, j].G, raw2[i, j].B) && Hue(raw2[i, j].G, raw2[i, j].B) < 180 && Saturation(raw2[i, j].G, raw2[i, j].B) > 20 && Saturation(raw2[i, j].G, raw2[i, j].B) < 80)
                    {
                        flag = 1;
                    }
                    if (flag == 1)
                    {
          
                        res[i, j].R = res[i, j].G = res[i, j].B = 255;

                    }
                    else {
                        res[i, j].R = res[i, j].G = res[i, j].B = 0;
                    }

                }
            }

            Bitmap bitmap= Tools.Builder(res,Width, Height);
            for(int i = 0; i < 5; i++)
            {
                Bitmap bitmap1 = FaceDetection.Dilation.Dilate(bitmap);
                bitmap = bitmap1;
            }

            res = Tools.Converter(bitmap);
            Tools.Raw[,] raaw = new Tools.Raw[Width, Height];
            Tools.Writer(bitmap);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    flag = 0;


                    if (res[i, j].R !=0 && 110 < Hue(raw2[i, j].G, raw2[i, j].B) && Hue(raw2[i, j].G, raw2[i, j].B) < 180 && 0 < Saturation(raw2[i, j].G, raw2[i, j].B) && Saturation(raw2[i, j].G, raw2[i, j].B) < 130)
                    {
                        flag = 1;
                    }
                    
                    if (flag == 1)
                    {

                        raaw[i, j].R = raaw[i, j].G = raaw[i, j].B = 255;

                    }
                    else {
                        raaw[i, j].R = raaw[i, j].G = raaw[i, j].B = 0;
                    }

                }
            }

            return raaw;

        }

    }
}
