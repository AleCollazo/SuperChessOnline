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
        private char?[,] tablero;
        private string movimiento;
        private char pieza;
        private string posicionInicial;
        private string posicionFinal;

        private void descomponerMovimiento()
        {
            pieza = Convert.ToChar(movimiento.Substring(0,1));
            posicionInicial = movimiento.Substring(1,2);
            posicionFinal = movimiento.Substring(3,2);
        }

        private int[] descomponerPosicion(string posicion)
        {
            int[] coordenadas = new int[2];

            coordenadas[0]= Convert.ToChar(posicionFinal.Substring(0, 1)) - 'A';
            coordenadas[1] = Convert.ToInt32(posicionFinal.Substring(1, 1)) - 1;

            return coordenadas;
        }

        public bool esUnaPiezaDelJugador()
        {
            if (jugadorTurno.isBlanco())
            {
                if (pieza < 'Z') return true;
                return false;
            }
            if (pieza > 'Z') return true;
            return false;
        }

        public bool hayPiezaDelJugador()
        {
            int[] coord = descomponerPosicion(posicionFinal);
            char? piezaTablero = tablero[coord[0], coord[1]];

            if (piezaTablero != null)
            {
                if (pieza < 'Z' && piezaTablero < 'Z') return true;

                if (pieza > 'Z' && piezaTablero > 'Z') return true;
            }
            return false;
        }

        public bool movimientoCorrectoPieza()
        {
            int[] coordIniciales = descomponerPosicion(posicionInicial);
            int[] coordFinales = descomponerPosicion(posicionFinal);

            switch (pieza)
            {
                case 'T':
                    return movimientoPieza.torre(coordIniciales[0],coordFinales[0], coordIniciales[1], coordFinales[1]);
                case 'C':
                    return movimientoPieza.caballo(coordIniciales[0], coordFinales[0], coordIniciales[1], coordFinales[1]);
                case 'A':
                    return movimientoPieza.afil(coordIniciales[0], coordFinales[0], coordIniciales[1], coordFinales[1]);
                case 'D':
                    return movimientoPieza.dama(coordIniciales[0], coordFinales[0], coordIniciales[1], coordFinales[1]);
                case 'R':
                    return movimientoPieza.rey(coordIniciales[0], coordFinales[0], coordIniciales[1], coordFinales[1]);
                case 'P':
                    return movimientoPieza.peon(coordIniciales[0], coordFinales[0], coordIniciales[1], coordFinales[1],
                        jugadorTurno.isBlanco(), this.comePiezaEnemiga());
            }
            return false;
        }

        public bool piezasTrayectoria()
        {
            
            if (pieza != 'C' && pieza != 'c')
            {
                int[] coordInicio = descomponerPosicion(posicionInicial);
                int[] coordFinal = descomponerPosicion(posicionFinal);

                for (int x = coordInicio[0]; x < coordFinal[0]; x++)
                {
                    for (int y = coordInicio[1]; x < coordFinal[1]; y++)
                    {
                        if (tablero[x, y] != null) return true;
                    }
                    for (int y = coordInicio[1]; x > coordFinal[1]; y--)
                    {
                        if (tablero[x, y] != null) return true;
                    }
                }
                for (int x = coordInicio[0]; x > coordFinal[0]; x--)
                {
                    for (int y = coordInicio[1]; x < coordFinal[1]; y++)
                    {
                        if (tablero[x, y] != null) return true;
                    }
                    for (int y = coordInicio[1]; x > coordFinal[1]; y--)
                    {
                        if (tablero[x, y] != null) return true;
                    }
                }
            }
            return false;
        }

        public bool comePiezaEnemiga()
        {
            int[] coord = descomponerPosicion(posicionFinal);
            char? piezaTablero = tablero[coord[0], coord[1]];

            if (piezaTablero != null)
            {
                if (pieza < 'Z' && piezaTablero > 'Z') return true;

                if (pieza > 'Z' && piezaTablero < 'Z') return true;
            }
            return false;
        }

        public bool haceJaque()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(tablero[i,j] != null && (jugadorTurno.isBlanco() & (tablero[i,j] < 'Z')))
                    {

                    }
                }
            }
            return true;
        }

        public bool haceJaqueMate()
        {
            return true;
        }

        public bool teHacenJaque()
        {
            return true;
        }

        public bool puedeEnrocar()
        {
            return true;
        }

        public void setJugada(Jugador jugadorTurno, string movimiento, char?[,] tablero)
        {
            this.jugadorTurno = jugadorTurno;
            this.movimiento = movimiento;
            this.tablero = tablero;
        }

        public char?[,] realizarMovimiento()
        {
            int[] coordIniciales = descomponerPosicion(posicionInicial);
            int[] coordFinales = descomponerPosicion(posicionFinal);
            tablero[coordIniciales[0], coordIniciales[1]] = null;
            tablero[coordFinales[0], coordFinales[1]] = pieza;
            return tablero;
        }
    }
}
