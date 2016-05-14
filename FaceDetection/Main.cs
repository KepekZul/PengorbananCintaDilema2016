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
        Image GambarAsli;
        string PathGambar = "";
        public Main()
        {
            InitializeComponent();
        }

        private void pilihGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Pilih = new OpenFileDialog();
            Pilih.FileName = "";
            Pilih.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            Pilih.ShowDialog();
            PathGambar = Pilih.FileName;
            if (PathGambar != "")
            {
                GambarAsli = Image.FromFile(PathGambar);
                Asal.Image = GambarAsli;
                Asal.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void Process_Click(object sender, EventArgs e)
        {

        }
    }
}
