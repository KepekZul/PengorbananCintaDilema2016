using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                GambarAsli = (Bitmap) Image.FromFile(PathGambar);
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
            this.GambarOlah = Olah.GambarOlah;
            Hasil.Image = this.GambarOlah;
            Hasil.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
