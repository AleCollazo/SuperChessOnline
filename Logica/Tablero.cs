using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class Tablero
    {
        private char?[,] tablero = new char?[8,8];
        private Comprobaciones comprobaciones;
        private Jugador jugadorBlancas;
        private Jugador jugadorNegras;
        private bool endGame;

        public Tablero(Jugador jugadorBlancas, Jugador jugadorNegras)
        {
            this.jugadorBlancas = jugadorBlancas;
            this.jugadorNegras = jugadorNegras;
            endGame = false;
        }

        public void colocarPiezaInicio()
        {
            //Colocar piezas blancas (Mayusculas)
            tablero[0, 0] = 'T';
            tablero[1, 0] = 'C';
            tablero[2, 0] = 'A';
            tablero[3, 0] = 'D';
            tablero[4, 0] = 'R';
            tablero[5, 0] = 'A';
            tablero[6, 0] = 'C';
            tablero[7, 0] = 'T';

            //Colocar piezas negras (Minusculas)
            tablero[0, 7] = 't';
            tablero[1, 7] = 'c';
            tablero[2, 7] = 'a';
            tablero[3, 7] = 'd';
            tablero[4, 7] = 'r';
            tablero[5, 7] = 'a';
            tablero[6, 7] = 'c';
            tablero[7, 7] = 't';

            //Colocar peones
            for (int i = 0; i < 8; i++)
            {
                tablero[i, 1] = 'P';
                tablero[i, 6] = 'p';
            }
        }

        

        public bool mover(string movimiento, bool turnoBlancas)
        {
            if (turnoBlancas)
            {
                comprobaciones.setJugada(jugadorBlancas, movimiento, tablero);
            }
            else
            {
                comprobaciones.setJugada(jugadorNegras, movimiento, tablero);
            }

            //Comprobaciones
            if (movimiento == "0-0" || movimiento == "0-0-0")
            {
                if (comprobaciones.puedeEnrocar()) return true;
                else return false;
            }

            if (!comprobaciones.movimientoCorrectoPieza()) return false;

            if (!comprobaciones.hayPiezaDelJugador()) return false;


            if (!comprobaciones.piezasTrayectoria()) return false;

            if (comprobaciones.comePiezaEnemiga())
            {

            }

            if (comprobaciones.haceJaque())
            {
                if (comprobaciones.haceJaqueMate())
                {
                    endGame = true;
                }
            }

            

            return true;
        }

        public bool isEndGame()
        {
            return endGame;
        }
    }
}
