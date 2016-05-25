using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FaceDetection
{
    class MedianFilter
    {
        public static Tools.Raw[,] Median(Tools.Raw[,] raw, int Width, int Height, int size)
        {
            double scale = (Width + Height) / 320;
            size = (int)(size *scale) ;
            Random random = new Random();
            int ApetureMin = -(size / 2);
            int ApetureMax = size / 2;
            Tools.Raw[,] riw = new Tools.Raw[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    List<double> RValues = new List<double>();
                    List<double> GValues = new List<double>();
                    List<double> BValues = new List<double>();
                    for(int i2 = ApetureMin; i2 < ApetureMax; i2++)
                    {
                        int tempX = i + i2;
                        if(tempX>=0 && tempX < Width)
                        {
                            for(int j2 = ApetureMin; j2 < ApetureMax; j2++)
                            {
                                int tempY = j + j2;
                                if(tempY >= 0 && tempY < Height)
                                {
                                    
                                    RValues.Add(raw[tempX,tempY].R);
                                    GValues.Add(raw[tempX,tempY].G);
                                    BValues.Add(raw[tempX,tempY].B);

                                }
                            }
                        }

                    }
                    RValues.Sort();
                    GValues.Sort();
                    BValues.Sort();
                    riw[i, j].R = RValues[RValues.Count / 2];
                    riw[i, j].G = GValues[GValues.Count / 2];
                    riw[i, j].B = BValues[BValues.Count / 2];
                    
                }
            }
            
            return riw;
        }


        public static Tools.Raw[,] Median1(Tools.Raw[,] raw, int Width, int Height, int size)
        {
            double scale = (Width + Height) / 320;
            size = (int)(size * scale);
            Random random = new Random();
            int ApetureMin = -(size / 2);
            int ApetureMax = size / 2;
            Tools.Raw[,] riw = new Tools.Raw[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    List<double> RValues = new List<double>();
                    
                    for (int i2 = ApetureMin; i2 < ApetureMax; i2++)
                    {
                        int tempX = i + i2;
                        if (tempX >= 0 && tempX < Width)
                        {
                            for (int j2 = ApetureMin; j2 < ApetureMax; j2++)
                            {
                                int tempY = j + j2;
                                if (tempY >= 0 && tempY < Height)
                                {

                                    RValues.Add(raw[tempX, tempY].R);
                                    

                                }
                            }
                        }

                    }
                    RValues.Sort();
                    
                    riw[i, j].R = RValues[RValues.Count / 2];
                    riw[i, j].G = raw[i, j].G;
                    riw[i, j].B = raw[i, j].B;
                    
                }
            }
            
            return riw;
        }

        public static Tools.Raw[,] Median2(Tools.Raw[,] raw, int Width, int Height, int size)
        {
            double scale = (Width + Height) / 320;
            size = (int)(size * scale);
            Random random = new Random();
            int ApetureMin = -(size / 2);
            int ApetureMax = size / 2;
            Tools.Raw[,] riw = new Tools.Raw[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    
                    List<double> GValues = new List<double>();
                    List<double> BValues = new List<double>();
                    for (int i2 = ApetureMin; i2 < ApetureMax; i2++)
                    {
                        int tempX = i + i2;
                        if (tempX >= 0 && tempX < Width)
                        {
                            for (int j2 = ApetureMin; j2 < ApetureMax; j2++)
                            {
                                int tempY = j + j2;
                                if (tempY >= 0 && tempY < Height)
                                {

                                    
                                    GValues.Add(raw[tempX, tempY].G);
                                    BValues.Add(raw[tempX, tempY].B);

                                }
                            }
                        }

                    }
                   
                    GValues.Sort();
                    BValues.Sort();
                    
                    riw[i, j].R = raw[i, j].R;
                    riw[i, j].G = GValues[GValues.Count / 2];
                    riw[i, j].B = BValues[BValues.Count / 2];
                   
                }
            }
            
            return riw;
        }

        
    }
}
