using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;


namespace FaceDetection
{
    public partial class Main : Form
    {
        Bitmap GambarAsli;
        Bitmap GambarOlah;
        Tools.Raw[,] raw;
        string PathGambar = "";
        public Main()
        {
            InitializeComponent();
        }

        private void pilihGambar_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog Pilih = new OpenFileDialog();
            Pilih.FileName = "";
            Pilih.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.gif) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.gif";
            Pilih.ShowDialog();
            PathGambar = Pilih.FileName;
            if (PathGambar != "")
            {
                Bitmap tmp = (Bitmap)Image.FromFile(PathGambar);
                Tools.Raw[,] raw = Tools.Converter(tmp);
                GambarAsli = tmp;
                Asal.Image = GambarAsli;
                Asal.SizeMode = PictureBoxSizeMode.Zoom;
                
            }
        }

        private void Process_Click(object sender, EventArgs e)
        {
            this.GambarOlah = this.GambarAsli;
      
            FaceDetection.lRgBy Olah = new lRgBy();
            Olah.GambarSumber = this.GambarOlah;
            Olah.raw = this.raw;
            Olah.convertToiRgBy(); //Convert to Channel IRgBy
            
            this.raw = FaceDetection.TextureMap.Process(Olah.raw, GambarOlah.Width, GambarOlah.Height); //Texturing, Detect Skin
            Bitmap bitmap = FaceDetection.Tools.Builder(this.raw, GambarOlah.Width, GambarOlah.Height); //Build from array to Bitmap
     
            convertToGrey convertImage = new convertToGrey();
            Bitmap GreyImage = convertImage.convert(this.GambarAsli);
            Bitmap MULTIPLIED = new Bitmap(convertImage.multiply(GreyImage, bitmap)); //Selecting Skin with real picture
            bitmap = FaceDetection.Histogram.CalculateHistogram(MULTIPLIED);
            bitmap = FaceDetection.Thresholding.Threshold(bitmap, 40, 240);
            
            //detecting Object
            ConnectedComponentsLabeling ccl = new ConnectedComponentsLabeling();
            ccl.FilterBlobs = true;
            ccl.MinWidth=40;
            bitmap = ccl.Apply(bitmap);
            
            //Memutihkan BLok warna
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    if (color.R != 0 || color.G != 0 || color.B != 0)
                    {
                        bitmap.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.Black);
                    }
                }
            }

            bitmap = FaceDetection.Dilation.Dilate(bitmap);
            MULTIPLIED = new Bitmap(convertImage.multiply(this.GambarAsli, bitmap));
           
            int x1,x2,y1,y2;
            x1 = y1 = 255;
            x2 = y2 = 0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color x = MULTIPLIED.GetPixel(i, j);
                    if (x.R != 0 && x.G !=0 && x.B !=0)
                    {
                        if (j <= y1)
                        {
                            y1 = j;
                        }
                        if (i >= x2)
                        {
                            x2 = i;
                        }
                        if (j >= y2)
                        {
                            y2 = j;
                        }
                        if (i <= x1)
                        {
                            x1 = i;
                        }
                    }
                }
            }
            
            
            Bitmap result = new Bitmap(GambarAsli);
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    result.SetPixel(x1, j, Color.FromArgb(255, 255, 255));
                    result.SetPixel(x2, j, Color.FromArgb(255, 255, 255));
                }
                result.SetPixel(i,y1, Color.FromArgb(255, 255, 255));
                result.SetPixel(i,y2, Color.FromArgb(255, 255, 255));
            }
            
            Hasil.Image = result;
            Hasil.SizeMode = PictureBoxSizeMode.Zoom;

        }
    }
}
