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

namespace Ejercicio_2
{
    public partial class Form1 : Form  //Ojo overflow. Cierre con pregunta. Falta icono. 
    {
        bool cerrar = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int rojo = 0;
                int verde = 0;
                int azul = 0;

                rojo = Convert.ToInt32(textBox1.Text);
                verde = Convert.ToInt32(textBox2.Text);
                azul = Convert.ToInt32(textBox3.Text);


                if (rojo < 0 || rojo > 255 || verde < 0 || verde > 255 || azul < 0 || azul > 255)
                {
                    label1.Text = "Número fuera de rango";
                    label1.ForeColor = Color.Red;
                    button2.BackColor = Color.Gainsboro;
                }
                else
                {
                    button2.BackColor = Color.FromArgb(rojo, verde, azul);
                    label1.Text = "";
                }
            }
            catch (FormatException error)
            {
                label1.Text = error.Message;
                label1.ForeColor = Color.Red;
                button2.BackColor = Color.Gainsboro;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //pictureBox1.ImageLocation = textBox4.Text;
                pictureBox1.Image = Image.FromFile(textBox4.Text);

            }
            catch (FileNotFoundException ex) when (ex is ArgumentException || ex is OverflowException)// mejor con when
            {
                pictureBox1.ImageLocation = "C:\\Users\\Samuel\\Documents\\error.png";

            }

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            AcceptButton = button3;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            AcceptButton = button2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                // Si el control es un TextBox restauramos su valor original
                if (c.GetType() == typeof(TextBox))
                {
                    if (c.Tag == null)
                    {
                        c.Text = "";
                    }
                    else
                    {
                        c.Text = c.Tag.ToString();
                    }
                }
                // Y si se trata de imagen, la quitamos
                if (c == pictureBox1)
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = DefaultBackColor;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Mi Aplicación",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}


