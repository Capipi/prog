using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_5  //Controla cantidades en ambas listas. Actualizar bien indices al quitar.
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        private string title = "Ejercicio 5 ";
        private int nLetras = 0;
        private Icon seta= Properties.Resources.seta;
        private Icon galeria = Properties.Resources.galeria;
        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(listBox2, listBox2.Items.Count.ToString());
            timer.Interval = 200;
            timer.Tick += letras;
            timer.Start();
        }

        private void letras(object sender, EventArgs e)
        {
            nLetras = (nLetras + 1) % (title.Length);//Si acaba la cadena empieza de nuevo
            this.Text = title.Substring(title.Length - nLetras) + title.Substring(0, title.Length - nLetras);
            //nLetras 0= ""+"123";
            //nLetras 1= "3"+"12";
            //nLetras 2= "32"+"1";
            if (nLetras % 2 == 0)
            {
                this.Icon = seta;
            }
            else
            {
                this.Icon = galeria;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Contains(textBox1.Text) || textBox1.Text == "")
            {

            }
            else
            {
                listBox1.Items.Add(textBox1.Text);
                label1.Text = listBox1.Items.Count.ToString();
            }
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label1.Text = listBox1.Items.Count.ToString();
            label2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            foreach (string item in listBox1.SelectedItems)
            {
                listBox2.Items.Add(item);
                list.Add(item);
            }
            foreach (string elemento in list)
            {
                listBox1.Items.Remove(elemento);
            }
            list.Clear();
            label1.Text = listBox1.Items.Count.ToString();
            toolTip1.SetToolTip(listBox2, listBox2.Items.Count.ToString());

        }

        //Indices bien ordenados--Así vale
        //Preguntar si hay evento especial para cuando cambie el tamaño--No lo hay
        //Gestion del transpasar--Así vale
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "";
            ArrayList seleccionados = new ArrayList();

            foreach (var item in listBox1.SelectedIndices)
            {
                seleccionados.Add(item);
            }
            foreach (var item in seleccionados)
            {
                label2.Text += "\n" + item.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            foreach (string item in listBox2.SelectedItems)
            {
                listBox1.Items.Add(item);
                list.Add(item);
            }
            foreach (string elemento in list)
            {
                listBox2.Items.Remove(elemento);
            }
            list.Clear();
            toolTip1.SetToolTip(listBox2, listBox2.Items.Count.ToString());
            label1.Text = listBox1.Items.Count.ToString();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
