using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection
{
    class Tools
    {
        public struct Raw
        {
            public double R;
            public double G;
            public double B;
        }
        public static Bitmap Builder(Raw[,] raw, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = Color.FromArgb((int)raw[i, j].R, (int)raw[i, j].G, (int)raw[i, j].B);
                    bitmap.SetPixel(i, j, color);
                }
            }
            return bitmap;
        }

        public static Raw[,] Converter(Bitmap bitmap)
        {
            Raw[,] raw = new Raw[bitmap.Width, bitmap.Height]; ;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    
                    raw[i, j].R = color.R;
                    raw[i, j].G = color.G;
                    raw[i, j].B = color.B;
                }
            }
            return raw;
        }
        public static void Writer(Bitmap bitmap)
        {
            try
            {
                System.IO.File.Delete("f:\\R.csv");
                System.IO.File.Delete("f:\\G.csv");
                System.IO.File.Delete("f:\\B.csv");
            }

            catch
            {

            }
            System.IO.StreamWriter file = new System.IO.StreamWriter("f:\\R.csv", true);
            System.IO.StreamWriter file1 = new System.IO.StreamWriter("f:\\G.csv", true);
            System.IO.StreamWriter file2 = new System.IO.StreamWriter("f:\\B.csv", true);



            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);

                    file.Write(color.R + ",");
                    file1.Write(color.G + ",");
                    file2.Write(color.B + ",");
                }
                file.WriteLine("");
                file1.WriteLine("");
                file2.WriteLine("");
            }
            file.Close();
            file1.Close();
            file2.Close();
        }

        public static void Writer(Raw[,] raw, int width, int height)
        {
            try
            {
                System.IO.File.Delete("f:\\R.csv");
                System.IO.File.Delete("f:\\G.csv");
                System.IO.File.Delete("f:\\B.csv");
            }

            catch
            {

            }
            System.IO.StreamWriter file = new System.IO.StreamWriter("f:\\Rn.csv", true);
            System.IO.StreamWriter file1 = new System.IO.StreamWriter("f:\\Gn.csv", true);
            System.IO.StreamWriter file2 = new System.IO.StreamWriter("f:\\Bn.csv", true);



            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    

                    file.Write(raw[i,j].R + ",");
                    file1.Write(raw[i,j].G + ",");
                    file2.Write(raw[i,j].B + ",");
                }
                file.WriteLine("");
                file1.WriteLine("");
                file2.WriteLine("");
            }
            file.Close();
            file1.Close();
            file2.Close();
        }
    }
}
