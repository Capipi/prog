namespace Ejercicio_7
{
    public partial class Form1 : Form
    {
        Aula aula = new Aula();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < aula.nombresAlumnos.Length; i++)
            {
                comboBox1.Items.Add(aula.nombresAlumnos[i]);
            }

            foreach (string asignatura in Enum.GetNames(typeof(Aula.Asignaturas)))
            {
                comboBox2.Items.Add(asignatura);
            }

            VisualizarTabla();

        }
        private void ComboBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaxMin.Text = aula.notaMaximaMinima(comboBox1.Text);
            ActualizarInformacion();
        }

        private void ActualizarInformacion()
        {
            // Obtener el nombre del alumno seleccionado
            string alumnoSeleccionado = comboBox1.SelectedItem?.ToString();
            // Obtener el nombre de la asignatura seleccionada
            string asignaturaSeleccionada = comboBox2.SelectedItem?.ToString();

            // Calcular la media general de la tabla
            double mediaTabla = aula.calcularMediaNotas();
            string textoInformacion = $"Media total de la tabla: {mediaTabla:F2}\n";

            // Calcular la media del alumno seleccionado (si hay alguno seleccionado)
            if (!string.IsNullOrEmpty(alumnoSeleccionado))
            {
                double mediaAlumno = aula.calcularMediaAlumno(alumnoSeleccionado);
                string maxMinAlumno = aula.notaMaximaMinima(alumnoSeleccionado);
                textoInformacion += $"Media de {alumnoSeleccionado}: {mediaAlumno:F2}\n{maxMinAlumno}\n";
            }

            // Calcular la media de la asignatura seleccionada (si hay alguna seleccionada)
            if (!string.IsNullOrEmpty(asignaturaSeleccionada))
            {
                double mediaAsignatura = aula.calcularMediaAsignatura(asignaturaSeleccionada);
                textoInformacion += $"Media de la asignatura {asignaturaSeleccionada}: {mediaAsignatura:F2}\n";
            }

            // Actualizar la etiqueta con la información
            infoLabel.Text = textoInformacion;
        }
        private void VisualizarTabla()
        {
            int startX = 50; // Posición inicial en X
            int startY = 100; // Posición inicial en Y
            int cellWidth = 100; // Ancho de cada celda
            int cellHeight = 30; // Altura de cada celda

            // Crear las cabeceras (asignaturas)
            for (int j = 0; j < aula.notas.GetLength(1); j++)
            {
                Label headerLabel = new Label
                {
                    Text = Enum.GetName(typeof(Aula.Asignaturas), j),
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Location = new Point(startX + (j + 1) * cellWidth, startY),
                    Size = new Size(cellWidth, cellHeight),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle
                };
                Controls.Add(headerLabel);
            }

            // Crear filas de alumnos y sus notas
            for (int i = 0; i < aula.nombresAlumnos.Length; i++)
            {
                // Etiqueta para el nombre del alumno
                Label alumnoLabel = new Label
                {
                    Text = aula.nombresAlumnos[i],
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    Location = new Point(startX, startY + (i + 1) * cellHeight),
                    Size = new Size(cellWidth, cellHeight),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle
                };
                Controls.Add(alumnoLabel);

                // Etiquetas para las notas del alumno en cada asignatura
                for (int j = 0; j < aula.notas.GetLength(1); j++)
                {
                    Label notaLabel = new Label
                    {
                        Text = aula.notas[i, j].ToString(),
                        Font = new Font("Arial", 9, FontStyle.Regular),
                        Location = new Point(startX + (j + 1) * cellWidth, startY + (i + 1) * cellHeight),
                        Size = new Size(cellWidth, cellHeight),
                        TextAlign = ContentAlignment.MiddleCenter,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.LightGray
                    };

                    // Crear un ToolTip para mostrar información adicional
                    ToolTip toolTip = new ToolTip();
                    toolTip.SetToolTip(notaLabel, $"Alumno: {aula.nombresAlumnos[i]}, Asignatura: {Enum.GetName(typeof(Aula.Asignaturas), j)}");

                    // Evento para cambiar el fondo al pasar el ratón por encima
                    notaLabel.MouseEnter += (sender, e) =>
                    {
                        notaLabel.BackColor = Color.Yellow;
                    };
                    notaLabel.MouseLeave += (sender, e) =>
                    {
                        notaLabel.BackColor = Color.LightGray;
                    };

                    Controls.Add(notaLabel);
                }
            }
        }
    }
}
