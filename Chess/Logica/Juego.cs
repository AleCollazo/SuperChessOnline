using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class Juego
    {
        public bool TurnoBlancas { get; set; }
        private Tablero tablero;
        public Tablero Tablero
        {
            get { return tablero; }
        }

        private Jugador jugador1;
        public Jugador Jugador1
        {
            get { return jugador1; }
        }
        private Jugador jugador2;
        public Jugador Jugador2 { get { return jugador2; } }


        public void iniciarJuego()
        {
            jugador1 = new Jugador(true, true);
            jugador2 = new Jugador(false, false);
            tablero = new Tablero(jugador1, jugador2);
            tablero.colocarPiezaInicio();
        }

        public void recibirMovimiento()
        {

        }

        public void enviarMovimiento()
        {

        }

        public void realizarTurno()
        {

        }

        public void finalizarJuego()
        {

        }
    }
}
