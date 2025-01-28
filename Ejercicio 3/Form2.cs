using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_3
{
    public partial class Form2 : Form
    {
        public Form2(string name, string rutaArchivo)
        {
            InitializeComponent();
            this.Text = name;
            pictureBox1.ImageLocation = rutaArchivo;

            Image image = Image.FromFile(rutaArchivo);

            pictureBox1.Size = new Size(image.Width, image.Height);
            ClientSize = pictureBox1.Size;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            pictureBox1.Size = ClientSize;
        }
    }
}
