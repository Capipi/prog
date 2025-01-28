using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_6
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        int contador = 0;
        string pin = "1231";
        string intento = "";
        public Form1()
        {
            InitializeComponent();

            form2.ShowDialog();
            int x = 179;
            int y = 120;
            for (int i = 1; i <= 12; i++)
            {
                Button button = new System.Windows.Forms.Button();
                button.Location = new System.Drawing.Point(x, y);
                button.Name = "button" + (2 + i).ToString();
                button.Size = new System.Drawing.Size(75, 23);
                button.TabIndex = 2 + i;
                if (i == 10)
                {
                    button.Text = "*";
                }
                else if (i == 11)
                {
                    button.Text = "0";
                }
                else if (i == 12)
                {
                    button.Text = "#";
                }
                else
                {
                    button.Text = i.ToString();
                }
                button.UseVisualStyleBackColor = true;
                form2.Controls.Add(button);
                if (i % 3 == 0)
                {
                    y += 50;
                    x = 179;
                }
                else
                {
                    x += 80;

                }

                button.Click += new System.EventHandler(this.button1_Click);
                button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
                button.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
                button.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
                this.Controls.Add(button);
            }
            Button reset = new System.Windows.Forms.Button();
            reset.Location = new System.Drawing.Point(424, 81);
            reset.Name = "button1";
            reset.Size = new System.Drawing.Size(75, 23);
            reset.TabIndex = 1;
            reset.Text = "Reset";
            reset.UseVisualStyleBackColor = true;
            reset.Click += new System.EventHandler(this.button1_Click_1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            textBox1.Text += bt.Text;
            if (textBox1.Text.Count() == 4)
            {
                if (textBox1.Text == pin)
                {
                    form2.Close();
                    contador = 0;
                }
                else
                {
                    contador++;
                    textBox1.Text = "";
                }
                if (contador == 3)
                {
                    form2.Close();
                }
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt.BackColor != Color.LightGreen)
            {
                bt.BackColor = Color.Yellow;
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt.BackColor != Color.LightGreen)
            {
                bt.BackColor = DefaultBackColor;
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.LightGreen;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.BackColor = DefaultBackColor;
                }
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Título: Ejercicio 6 (D.I.)\n Autor: Samuel Ramos", "Ejercicio 6", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.BackColor = DefaultBackColor;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text.Count() == 4)
            {
                if (textBox1.Text == pin)
                {
                    form2.Close();
                    contador = 0;
                }
                else
                {
                    contador++;
                    textBox1.Text = "";
                }
                if (contador == 3)
                {
                    form2.Close();
                }
            }
        }
    }
}
