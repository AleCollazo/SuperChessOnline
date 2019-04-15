using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class Tablero
    {
        private char[,] tablero = new char[8,8];
        private Comprobaciones comprobaciones;
        private Jugador jugador1;
        private Jugador jugador2;

        public Tablero(Jugador jugador1, Jugador jugador2)
        {
            this.jugador1 = jugador1;
            this.jugador2 = jugador2;
        }

        public void colocarPiezaInicio()
        {

        }

        public bool mover(string movimiento, bool turnoBlancas)
        {
            return true;
        }

    }
}
