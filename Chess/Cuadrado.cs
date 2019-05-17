using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Cuadrado
    {
        public string Nombre { get; }
        public bool Blanco { get; }
        public string Seleccionado { get; set; }

        public Cuadrado(string nombre, bool blanco)
        {
            Nombre = nombre;
            Blanco = blanco;
        }
    }
}
