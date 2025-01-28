using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    internal class Aula
    {
        public string[] nombresAlumnos;
        public int[,] notas;

        public enum Asignaturas
        {
            Pociones, Quidditch, Criaturas, ArtesOscuras
        }
        public Aula()
        {
            // Cargar los nombres de los alumnos desde el archivo al inicializar el objeto
            nombresAlumnos = LeerNombresDesdeArchivo();
            notas = new int[nombresAlumnos.Length, Enum.GetNames(typeof(Asignaturas)).Length];
            PonerNotasAleatorias();
        }
        private string[] LeerNombresDesdeArchivo()
        {
            // Obtener la ruta del directorio del usuario
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "nombres.txt");

            // Verificar si el archivo existe
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("El archivo 'nombres.txt' no se encontró en el directorio del usuario.");
                return new string[0]; // Devolver un array vacío si no existe el archivo
            }

            try
            {
                // Leer el contenido del archivo
                string contenido = File.ReadAllText(rutaArchivo);

                // Separar los nombres por comas y devolver un array de nombres
                string[] nombres = contenido.Split(',');
                for (int i = 0; i < nombres.Length; i++)
                {
                    nombres[i] = nombres[i].Trim(); // Eliminar espacios en blanco
                }
                return nombres;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo: " + ex.Message);
                return new string[0];
            }
        }
        private void PonerNotasAleatorias()
        {
            Random random = new Random();
            for (int i = 0; i < notas.GetLength(0); i++)// Filas alumnos
            {
                for (int j = 0; j < notas.GetLength(1); j++)// Columnas asignaturas
                {
                    notas[i, j] = random.Next(0, 11);
                }
            }
        }

        public double calcularMediaNotas()
        {
            int media = 0;
            for (int i = 0; i < notas.GetLength(0); i++)// Filas alumnos
            {
                for (int j = 0; j < notas.GetLength(1); j++)// Columnas asignaturas
                {
                    media += notas[i, j];
                }
            }
            return media / notas.GetLength(0) * notas.GetLength(1);
        }

        // Indexador para acceder a las notas usando [alumno, asignatura] es como la posición del array bi [i][j]
        public int this[int alumno, int asignatura]
        {
            set
            {
                notas[alumno, asignatura] = value;
            }
            get
            {
                return notas[alumno, asignatura];
            }
        }
        public double calcularMediaAlumno(string nombreAlumno)
        {
            int mediaAlumno = 0;
            for (int i = 0; i < nombresAlumnos.Length; i++)
            {
                if (nombreAlumno.ToUpper() == nombresAlumnos[i])
                {
                    for (int j = 0; j < notas.GetLength(1); j++)
                    {
                        mediaAlumno += this[i, j]; //i==Alumno y j==asignatura
                    }
                }
            }
            return mediaAlumno / notas.GetLength(1);
        }

        public double calcularMediaAsignatura(string asignatura)
        {
            int mediaAsignatura = 0;

            // Convertir el string asignatura en el valor correspondiente del Enum Asignaturas
            if (Enum.TryParse(asignatura.Trim(), true, out Asignaturas asignaturaEnum)) //-->Intenta convertir el valor del Enum asignaturas (el true o false es si ignora o no mayúsculas/min el convertir) si bien, lo guarda en asignaturaEnum;
            {
                // Convertir el Enum Asignatura a indice correspondiente
                int indiceAsignatura = (int)asignaturaEnum;

                // Sumar las notas de todos los alumnos para esta asignatura
                for (int i = 0; i < notas.GetLength(0); i++)
                {
                    mediaAsignatura += this[i, indiceAsignatura]; // Accede usando el indexador
                }

                return mediaAsignatura / notas.GetLength(0);
            }
            else
            {
                //Nombre en el parámetro incorrecto
                return 0;
            }
        }

        public string notaMaximaMinima(string nombreAlumno)
        {
            double max = 0;
            double min = 10;

            for (int i = 0; i < nombresAlumnos.Length; i++)
            {
                if (nombreAlumno.ToUpper() == nombresAlumnos[i])
                {
                    for (int j = 0; j < notas.GetLength(1); j++)
                    {
                        if (notas[i, j] > max)
                        {
                            max = notas[i, j];
                        }
                        if (notas[i, j] < min)
                        {
                            min = notas[i, j];
                        }
                    }
                }
            }

            string finalNotas = string.Format("La nota más alta fue {0}, la más baja {1}", max, min);
            return finalNotas;
        }
    }
}
