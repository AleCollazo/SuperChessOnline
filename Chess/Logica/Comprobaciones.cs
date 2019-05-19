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

        public Comprobaciones()
        {
            movimientoPieza = new MovimientoPieza();
        }

        private void descomponerMovimiento()
        {
            pieza = Convert.ToChar(movimiento.Substring(0,1));
            posicionInicial = movimiento.Substring(1,2);
            posicionFinal = movimiento.Substring(3,2);
        }

        private int[] descomponerPosicion(string posicion)
        {
            int[] coordenadas = new int[2];

            //Console.WriteLine("posicion " + posicion);

            coordenadas[0]= Convert.ToChar(posicion.Substring(0, 1)) - 'A';
            coordenadas[1] = Convert.ToInt32(posicion.Substring(1, 1)) - 1;

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

            //Console.WriteLine();
            //Console.WriteLine("MovimientoCorrectoPieza:");
            //Console.WriteLine("pieza "+ pieza);

            switch (pieza)
            {
                case 'T':
                case 't':
                    return movimientoPieza.torre(coordIniciales[0], coordIniciales[1], coordFinales[0], coordFinales[1]);
                case 'C':
                case 'c':
                    return movimientoPieza.caballo(coordIniciales[0], coordIniciales[1], coordFinales[0], coordFinales[1]);
                case 'A':
                case 'a':
                    return movimientoPieza.afil(coordIniciales[0], coordIniciales[1], coordFinales[0], coordFinales[1]);
                case 'D':
                case 'd':
                    return movimientoPieza.dama(coordIniciales[0], coordIniciales[1], coordFinales[0], coordFinales[1]);
                case 'R':
                case 'r':
                    return movimientoPieza.rey(coordIniciales[0], coordIniciales[1], coordFinales[0], coordFinales[1]);
                case 'P':
                case 'p':
                    return movimientoPieza.peon(coordIniciales[0], coordIniciales[1], coordFinales[0], coordFinales[1],
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

                int iInicio, iFinal;
                

                if (Math.Abs(coordInicio[0] - coordFinal[0]) == Math.Abs(coordInicio[1] - coordFinal[1]))
                {
                    int j;
                    Console.WriteLine("Dentro diagonal");
                    if ((coordInicio[0] - coordFinal[0]) == (coordInicio[1] - coordFinal[1]))
                    {
                        iInicio = coordInicio[0];
                        iFinal = coordFinal[0];
                        j = coordInicio[1] ;
                        for (int i = iInicio + 1; i < iFinal; i++)
                        {
                            Console.WriteLine("i {0}", i);
                            Console.WriteLine("Diagonal deracha-arriba: {0}", tablero[i, i] != null);
                            j++;
                            if (tablero[i, j] != null) return true;
                            
                        }
                        for (int i = iInicio - 1; i > iFinal; i--)
                        {
                            Console.WriteLine("i {0}", i);
                            Console.WriteLine("Diagonal izquierda-abajo: {0}", tablero[i, i] != null);
                            j--;
                            if (tablero[i, j] != null) return true;
                        }
                    }
                    else
                    {
                        iInicio = coordInicio[0];
                        iFinal = coordFinal[0];
                        j = coordInicio[1];
                        for (int i = iInicio + 1; i < iFinal; i++)
                        {
                            Console.WriteLine("Diagonal deracha-abajo: {0}", tablero[i, coordInicio[1] - i] != null);
                            j--;
                            if (tablero[i, j] != null) return true;
                        }
                        for (int i = iInicio - 1; i > iFinal; i--)
                        {
                            Console.WriteLine("i {0} coordInicio {1}", i, coordInicio[1] + i);
                            Console.WriteLine("Diagonal izquierda-arriba: {0}", tablero[i, coordInicio[1] + i] != null);
                            j++;
                            if (tablero[i, j] != null) return true;
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Dentro lineal");
                    if (coordInicio[0] == coordFinal[0])
                    {
                        Console.WriteLine("Dentro vertical");
                        iInicio = coordInicio[1];
                        iFinal = coordFinal[1];
                        for (int i = iInicio + 1; i < iFinal; i++)
                        {
                            Console.WriteLine("Vertical arriba: {0}", tablero[coordInicio[0], i] != null);
                            if (tablero[coordInicio[0], i] != null) return true;
                        }
                        for (int i = iInicio - 1; i > iFinal; i--)
                        {
                            Console.WriteLine("Vertical abajo: {0}", tablero[coordInicio[0], i] != null);
                            if (tablero[coordInicio[0], i] != null) return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dentro horizontal");
                        iInicio = coordInicio[0];
                        iFinal = coordFinal[0];
                        for (int i = iInicio + 1; i < iFinal; i++)
                        {
                            Console.WriteLine("Derecha: {0}", tablero[i, coordInicio[1]] != null);
                            if (tablero[i, coordInicio[1]] != null) return true;
                        }
                        for (int i = iInicio - 1; i > iFinal; i--)
                        {
                            Console.WriteLine("Izquierda: {0}", tablero[i, coordInicio[1]] != null);
                            Console.WriteLine("i {0} coordInicio {1}", i, coordInicio[1]);
                            if (tablero[i, coordInicio[1]] != null) return true;
                        }
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
            descomponerMovimiento();
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
