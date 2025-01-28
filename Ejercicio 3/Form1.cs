using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ejercicio_3 //icono secundario, abre no modal al cerrar modal
{//Al inicio el formulario ajustado a la imagen (y usa clientsize)
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Visor de imágenes";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open File Dialog";
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Imagen|*.jpg;*.png|Todos|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                Form2 f2 = new Form2(fileName, filePath);
                if (checkBox1.Checked)
                {
                    f2.ShowDialog();
                }
                else
                {
                    f2.Show();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//Probar a hacer ternaria
        {
            checkBox1.ForeColor = checkBox1.Checked? Color.Red:    Color.Black;
            
            //if (checkBox1.Checked)
            //{
            //    checkBox1.ForeColor = Color.Red;
            //}
            //else
            //{
            //    checkBox1.ForeColor = Color.Black;
            //}
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere salir?"
                , "Confirmación"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
