using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_4
{
    // Texto del botón, AcceeptButton, solo funciona la suma
    public partial class Form1 : Form
    {
        public delegate int Operation(int a, int b);

        //La diferencia entre la hashtable y el dictionary es que la hashtable usa objetos, entonces luego habría que hacer cast para poder especificar valores.
        Dictionary<string, Operation> operaciones = new Dictionary<string, Operation>();

        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            operaciones.Add("+", (int a, int b) => a + b);
            operaciones.Add("-", (int a, int b) => a - b);
            operaciones.Add("x", (int a, int b) => a * b);
            operaciones.Add("/", (int a, int b) => a / b);

            timer.Interval = 1000;
            timer.Tick += crono;
            timer.Start();
        }
        int contador = 0;
        private void crono(object sender, EventArgs e)
        {
            contador++;
            int minutos = contador / 60;
            int segundos = contador % 60;
            this.Text = string.Format("{0:D2}:{1:D2}", minutos, segundos);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                label1.Text = rb.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n1;
            int n2;
            bool convierte1;
            bool convierte2;

            convierte1 = int.TryParse(textBox1.Text, out n1);
            convierte2 = int.TryParse(textBox2.Text, out n2);
            if (!convierte1 || !convierte2)
            {
                label2.Text = "Número no valido";
                label2.ForeColor = Color.Red;
            }
            else if (label1.Text == "/" && n2 == 0)
            {
                label2.Text = "No se puede dividir entre 0";
                convierte2 = false;
                label2.ForeColor = Color.Red;
            }
            else
            {
                label2.Text = operaciones[label1.Text](n1, n2).ToString();
                //foreach (Control c in Controls)
                //{
                //    if (c.GetType() == typeof(RadioButton))
                //    {
                //        if (((RadioButton)c).Checked)
                //        {
                //        }
                //    }
                //}
                label2.ForeColor = DefaultForeColor;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (int.TryParse(textBox.Text, out _))//_ Es descarte, porque no puede estar vacio(creo)
            {
                textBox.BackColor = DefaultBackColor;
            }
            else
            {
                textBox.BackColor = Color.Red;
            }
        }
    }
}
