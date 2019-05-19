using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class Tablero
    {
        public char?[,] TableroPiezas { get; set; }
        private Comprobaciones comprobaciones;
        private Jugador jugadorBlancas;
        private Jugador jugadorNegras;
        private bool endGame;

        public Tablero(Jugador jugadorBlancas, Jugador jugadorNegras)
        {
            comprobaciones = new Comprobaciones();
            TableroPiezas = new char?[8, 8];
            this.jugadorBlancas = jugadorBlancas;
            this.jugadorNegras = jugadorNegras;
            endGame = false;
        }

        public void colocarPiezaInicio()
        {
            //Colocar piezas blancas (Mayusculas)
            TableroPiezas[0, 0] = 'T';
            TableroPiezas[1, 0] = 'C';
            TableroPiezas[2, 0] = 'A';
            TableroPiezas[3, 0] = 'D';
            TableroPiezas[4, 0] = 'R';
            TableroPiezas[5, 0] = 'A';
            TableroPiezas[6, 0] = 'C';
            TableroPiezas[7, 0] = 'T';

            //Colocar piezas negras (Minusculas)
            TableroPiezas[0, 7] = 't';
            TableroPiezas[1, 7] = 'c';
            TableroPiezas[2, 7] = 'a';
            TableroPiezas[3, 7] = 'd';
            TableroPiezas[4, 7] = 'r';
            TableroPiezas[5, 7] = 'a';
            TableroPiezas[6, 7] = 'c';
            TableroPiezas[7, 7] = 't';

            //Colocar peones
            for (int i = 0; i < 8; i++)
            {
                TableroPiezas[i, 1] = 'P';
                TableroPiezas[i, 6] = 'p';
            }
        }

        

        public bool mover(string movimiento, bool turnoBlancas)
        {
            if (turnoBlancas)
            {
                comprobaciones.setJugada(jugadorBlancas, movimiento, TableroPiezas);
            }
            else
            {
                comprobaciones.setJugada(jugadorNegras, movimiento, TableroPiezas);
            }

            //Comprobaciones
            if (movimiento == "0-0" || movimiento == "0-0-0")
            {
                if (comprobaciones.puedeEnrocar()) return true;
                else return false;
            }

            if (!comprobaciones.movimientoCorrectoPieza()) return false;

            //Console.WriteLine("movimientoCorrectoPieza");

            if (comprobaciones.hayPiezaDelJugador()) return false;

            //Console.WriteLine("hayPiezaDelJugador");

            if (comprobaciones.piezasTrayectoria()) return false;

            //Console.WriteLine("piezasTrayectoria");

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

            TableroPiezas = comprobaciones.realizarMovimiento();

            return true;
        }

        public bool isEndGame()
        {
            return endGame;
        }

        
    }
}
