using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploExamen
{
    internal class Record
    {
        public string Nombre { get; set; }
        private int edad;
        public int Puntuacion { get; set; }

        public int Edad
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La edad no puede ser menor a 0");
                }
                else
                {
                    edad = value;
                }
            }
            get
            {
                return edad;
            }
        }
        public Record(string nombre, int edad, int puntuacion)
        {
            Nombre = nombre;
            Edad = edad;
            Puntuacion = puntuacion;
        }

        public override string ToString()
        {
            return $"{Nombre}, Edad: {Edad}, Puntuación: {Puntuacion}";
        }
    }
}
