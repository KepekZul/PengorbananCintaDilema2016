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
                //GambarAsli = 

                Tools.Raw[,] raw = Tools.Converter(tmp);
                GambarAsli = tmp;
                Asal.Image = GambarAsli;
                Asal.SizeMode = PictureBoxSizeMode.Zoom;
                //Scale = (GambarAsli.Width + GambarAsli.Height) / 320;
            }
        }

        private void Process_Click(object sender, EventArgs e)
        {

            this.GambarOlah = this.GambarAsli;
            //Tools.Writer(this.GambarOlah);
            FaceDetection.lRgBy Olah = new lRgBy();
            Olah.GambarSumber = this.GambarOlah;
            Olah.raw = this.raw;
            Olah.convertToiRgBy();
            //Tools.Writer(Olah.raw, GambarOlah.Width, GambarOlah.Height);
            this.raw = FaceDetection.TextureMap.Process(Olah.raw, GambarOlah.Width, GambarOlah.Height);
            Bitmap bitmap = FaceDetection.Tools.Builder(this.raw, GambarOlah.Width, GambarOlah.Height);
            BoundaryTracing trace = new BoundaryTracing(bitmap);
            trace.traceBoundary();
            bitmap = new Bitmap(trace.transformImage(bitmap));
            /*Bitmap GreyImage;
            convertToGrey convertImage = new convertToGrey();
            GreyImage = convertImage.convert(this.GambarAsli);
            Bitmap MULTIPLIED;
            MULTIPLIED = new Bitmap( convertImage.multiply(GreyImage, bitmap));
            //this.GambarOlah = Olah.GambarOlah;
            //this.GambarOlah = FaceDetection.TextureMap.Process(Olah.GambarOlah);*/
            Hasil.Image = bitmap;
            Hasil.SizeMode = PictureBoxSizeMode.Zoom;

        }
    }
}
