namespace FaceDetection
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Asal = new System.Windows.Forms.PictureBox();
            this.Hasil = new System.Windows.Forms.PictureBox();
            this.pilihGambar = new System.Windows.Forms.Button();
            this.Process = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Asal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hasil)).BeginInit();
            this.SuspendLayout();
            // 
            // Asal
            // 
            this.Asal.BackColor = System.Drawing.SystemColors.Control;
            this.Asal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Asal.InitialImage = null;
            this.Asal.Location = new System.Drawing.Point(12, 12);
            this.Asal.Name = "Asal";
            this.Asal.Size = new System.Drawing.Size(300, 300);
            this.Asal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Asal.TabIndex = 0;
            this.Asal.TabStop = false;
            // 
            // Hasil
            // 
            this.Hasil.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Hasil.Location = new System.Drawing.Point(318, 12);
            this.Hasil.Name = "Hasil";
            this.Hasil.Size = new System.Drawing.Size(300, 300);
            this.Hasil.TabIndex = 1;
            this.Hasil.TabStop = false;
            // 
            // pilihGambar
            // 
            this.pilihGambar.Location = new System.Drawing.Point(12, 318);
            this.pilihGambar.Name = "pilihGambar";
            this.pilihGambar.Size = new System.Drawing.Size(98, 23);
            this.pilihGambar.TabIndex = 2;
            this.pilihGambar.Text = "Select Photo";
            this.pilihGambar.UseVisualStyleBackColor = true;
            this.pilihGambar.Click += new System.EventHandler(this.pilihGambar_Click);
            // 
            // Process
            // 
            this.Process.Location = new System.Drawing.Point(117, 319);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(98, 23);
            this.Process.TabIndex = 3;
            this.Process.Text = "Process Image";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 386);
            this.Controls.Add(this.Process);
            this.Controls.Add(this.pilihGambar);
            this.Controls.Add(this.Hasil);
            this.Controls.Add(this.Asal);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.Asal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hasil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Asal;
        private System.Windows.Forms.PictureBox Hasil;
        private System.Windows.Forms.Button pilihGambar;
        private System.Windows.Forms.Button Process;
    }
}

