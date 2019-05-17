using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pieza
    {
        public char Nombre { get; }
        public string PosicionTablero { get; }
        public bool Selecionada { get; set; }
        public bool Blanca { get; }

        public Pieza(char nombre, string posicionTablero, bool blanca)
        {
            Selecionada = false;
            Nombre = nombre;
            PosicionTablero = posicionTablero;
            Blanca = blanca;
        }
    }
}
