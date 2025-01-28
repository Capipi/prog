namespace EjemploExamen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnJugar = new Button();
            BtnReset = new Button();
            BtnSalir = new Button();
            LstNombres = new ListBox();
            BtnEliminar = new Button();
            menuStrip1 = new MenuStrip();
            accionesToolStripMenuItem = new ToolStripMenuItem();
            jugarToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            salirToolStripMenuItem = new ToolStripMenuItem();
            lblResultados = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnJugar
            // 
            BtnJugar.BackColor = Color.Gray;
            BtnJugar.Location = new Point(428, 36);
            BtnJugar.Name = "BtnJugar";
            BtnJugar.Size = new Size(75, 23);
            BtnJugar.TabIndex = 0;
            BtnJugar.Text = "BtnJugar";
            BtnJugar.UseVisualStyleBackColor = false;
            // 
            // BtnReset
            // 
            BtnReset.BackColor = Color.Gray;
            BtnReset.Location = new Point(428, 65);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(75, 23);
            BtnReset.TabIndex = 1;
            BtnReset.Text = "BtnReset";
            BtnReset.UseVisualStyleBackColor = false;
            // 
            // BtnSalir
            // 
            BtnSalir.BackColor = Color.Gray;
            BtnSalir.Location = new Point(428, 94);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(75, 23);
            BtnSalir.TabIndex = 2;
            BtnSalir.Text = "BtnSalir";
            BtnSalir.UseVisualStyleBackColor = false;
            BtnSalir.Click += salirToolStripMenuItem_Click;
            // 
            // LstNombres
            // 
            LstNombres.FormattingEnabled = true;
            LstNombres.ItemHeight = 15;
            LstNombres.Location = new Point(579, 73);
            LstNombres.Name = "LstNombres";
            LstNombres.Size = new Size(120, 94);
            LstNombres.TabIndex = 3;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Location = new Point(588, 205);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(83, 23);
            BtnEliminar.TabIndex = 4;
            BtnEliminar.Text = "BtnEliminar";
            BtnEliminar.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { accionesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // accionesToolStripMenuItem
            // 
            accionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { jugarToolStripMenuItem, resetToolStripMenuItem, toolStripSeparator1, salirToolStripMenuItem });
            accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            accionesToolStripMenuItem.ShortcutKeyDisplayString = "A";
            accionesToolStripMenuItem.Size = new Size(67, 20);
            accionesToolStripMenuItem.Text = "&Acciones";
            // 
            // jugarToolStripMenuItem
            // 
            jugarToolStripMenuItem.Name = "jugarToolStripMenuItem";
            jugarToolStripMenuItem.ShortcutKeys = Keys.F5;
            jugarToolStripMenuItem.Size = new Size(180, 22);
            jugarToolStripMenuItem.Text = "&Jugar";
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.ShortcutKeys = Keys.F6;
            resetToolStripMenuItem.Size = new Size(180, 22);
            resetToolStripMenuItem.Text = "&Reset";
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            salirToolStripMenuItem.Size = new Size(180, 22);
            salirToolStripMenuItem.Text = "&Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // lblResultados
            // 
            lblResultados.AutoSize = true;
            lblResultados.Location = new Point(588, 259);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(64, 15);
            lblResultados.TabIndex = 6;
            lblResultados.Text = "Resultados";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResultados);
            Controls.Add(BtnEliminar);
            Controls.Add(LstNombres);
            Controls.Add(BtnSalir);
            Controls.Add(BtnReset);
            Controls.Add(BtnJugar);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Loteria Simple";
            FormClosing += Form1_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnJugar;
        private Button BtnReset;
        private Button BtnSalir;
        private ListBox LstNombres;
        private Button BtnEliminar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem accionesToolStripMenuItem;
        private ToolStripMenuItem jugarToolStripMenuItem;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private Label lblResultados;
    }
}
