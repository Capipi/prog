//#define Char
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Form1 : Form   //Arreglar directiva
    {
        public Form1()
        {
            InitializeComponent();
            int x = 179;
            int y = 120;
            for (int i = 1; i <= 20; i++)
            {
                Button button = new System.Windows.Forms.Button();
                button.Location = new System.Drawing.Point(x, y);
                button.Name = "button" + (2 + i).ToString();
                button.Size = new System.Drawing.Size(75, 23);
                button.TabIndex = 2 + i;
                button.Text = i.ToString();
                button.UseVisualStyleBackColor = true;
                button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
                //button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Down);
                button.Click += new System.EventHandler(this.button_Click);
                Controls.Add(button);
                if (i % 5 == 0)
                {
                    y += 50;
                    x = 179;
                }
                else
                {
                    x += 80;

                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            if (sender.GetType() == typeof(Button))
            {
                Button btn = (Button)sender;
                x += btn.Location.X;
                y += btn.Location.Y;
            }
            this.Text = String.Format("X: {0}, Y: {1}", x, y);
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "Mouse Tester";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.Green;
            }
            else
            {
                button1.BackColor = Color.Red;
                button2.BackColor = Color.Green;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.Gainsboro;
            }
            else if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.Gainsboro;
            }
            else
            {
                button1.BackColor = Color.Gainsboro;
                button2.BackColor = Color.Gainsboro;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
#if Char
            if (e.KeyCode == Keys.Escape)
            {
                this.Text = "Mouse Tester";
            }
            else
            {
                this.Text = e.KeyCode.ToString();
            }
#endif
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
#if !Char

            this.Text = e.KeyChar.ToString();
#endif
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

        //private void Button_Down(object sender, EventArgs e)
        //{
        //    if (sender is Button btn)
        //    {
        //        this.Text = btn.Text;
        //    }
        //}

        private void button_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                this.Text = btn.Text;
            }
        }
    }
}
