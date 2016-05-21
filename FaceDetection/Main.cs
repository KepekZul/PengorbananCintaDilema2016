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

namespace FaceDetection
{
    public partial class Main : Form
    {
        Bitmap GambarAsli;
        int Scale;
        Bitmap GambarOlah;
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
                Bitmap tmp= (Bitmap)Image.FromFile(PathGambar);
                //GambarAsli = 
                Bitmap gambar = new Bitmap(tmp.Width, tmp.Height, PixelFormat.Format32bppRgb);
                for(int i = 0; i < tmp.Width; i++)
                {
                    for(int j = 0; j < tmp.Height; j++)
                    {
                        Color pix = tmp.GetPixel(i, j);
                        //Color newC = Color.FromArgb(pix.R, 0,0);
                        gambar.SetPixel(i, j, pix);
                    }
                }
                GambarAsli = gambar;
                Asal.Image = GambarAsli;
                Asal.SizeMode = PictureBoxSizeMode.Zoom;
                Scale = (GambarAsli.Width + GambarAsli.Height) / 320;
            }
        }

        private void Process_Click(object sender, EventArgs e)
        {
            
            this.GambarOlah = this.GambarAsli;
            FaceDetection.lRgBy Olah = new lRgBy();
            Olah.GambarSumber = this.GambarOlah;
            Olah.convertToiRgBy();
            //this.GambarOlah = Olah.GambarOlah;
            this.GambarOlah = FaceDetection.TextureMap.Process(Olah.GambarOlah);
            Hasil.Image = Olah.GambarOlah;
            Hasil.SizeMode = PictureBoxSizeMode.Zoom;
            
        }
    }
}
