using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class Comprobaciones
    {
        private MovimientoPieza movimientoPieza;
        private Jugador jugadorTurno;
        private char[,] tablero;
        private string movimiento;
        private char pieza;
        private string posicionInicial;
        private string posicionFinal;

        private void descomponerMovimiento()
        {

        }

        public bool hayPiezaDelJugador()
        {
            return true;
        }

        public bool movimientoCorrectoPieza()
        {
            return true;
        }

        public bool piezasTrayectoria()
        {
            return true;
        }

        public bool comePiezaEnemiga()
        {
            return true;
        }

        public bool haceJaque()
        {
            return true;
        }

        public bool haceJaqueMate()
        {
            return true;
        }

        public bool puedeEnrocar()
        {
            return true;
        }

        public void setJugada(Jugador jugadorTurno, string movimiento, char[,] tablero)
        {
            this.jugadorTurno = jugadorTurno;
            this.movimiento = movimiento;
            this.tablero = tablero;
        }
    }
}
