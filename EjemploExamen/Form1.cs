using Timer = System.Windows.Forms.Timer;

namespace EjemploExamen
{
    public partial class Form1 : Form
    {
        ToolTip toolTip = new ToolTip();
        Timer timer = new Timer();
        int contador = 0;
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 300;
            timer.Tick += colores;
            timer.Start();

            int x = 30;
            int y = 30;
            for (int i = 0; i < 49; i++)
            {
                CheckBox checkBox = new CheckBox();
                if (i % 9 == 0)
                {
                    y += 40;
                    x = 30;
                }
                else
                {
                    x += 40;
                }
                checkBox.Location = new Point(x, y);
                checkBox.AutoSize = true;
                checkBox.Size = new Size(30, 30);
                checkBox.Text = (i + 1).ToString(); ;
                toolTip.SetToolTip(checkBox, "No marcado");

                checkBox.CheckedChanged += checkBox1_CheckedChanged;
                this.Controls.Add(checkBox);
            }

        }

        private void colores(object sender, EventArgs e)
        {
            if (contador % 2 == 0)
            {
                BtnJugar.BackColor = Color.Yellow;
                BtnReset.BackColor = Color.Yellow;
                BtnSalir.BackColor = Color.Yellow;
            }
            else
            {
                BtnJugar.BackColor = Color.Beige;
                BtnReset.BackColor = Color.Beige;
                BtnSalir.BackColor = Color.Beige;
            }
            contador++;
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lblResultados.Text = "";
            bool marcados = false;
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(CheckBox))
                {
                    if (((CheckBox)c).Checked)
                    {
                        lblResultados.Text += c.Text + "\n";
                        marcados = true;
                    }
                }
            }
            if (!marcados)
            {
                lblResultados.Text = "Resultados";
            }
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
            {
                toolTip.SetToolTip(chk, "Marcado");
            }
            else
            {
                toolTip.SetToolTip(chk, "No marcado");
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(CheckBox))
                {
                    if (((CheckBox)c).Checked)
                    {
                        ((CheckBox)c).Checked = false;
                        ((CheckBox)c).BackColor = DefaultBackColor;
                        toolTip.SetToolTip(c, "No marcado");
                    }
                }
                else
                {
                    lblResultados.Text = "Resultados";
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LstNombres.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show("Se saldrá de la aplicación", "¿Desea salir?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }

}
