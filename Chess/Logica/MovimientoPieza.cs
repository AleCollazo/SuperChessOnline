using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class MovimientoPieza
    {
        public bool peon(int xInicial, int yInicial, int xFinal, int yFinal, bool blanco, bool comePieza)
        {
            //Console.WriteLine();
            //Console.WriteLine("Peon");
            //Console.WriteLine(String.Format("xi {0}  yi {1}  xf{2}   yf{2}",
              //  xInicial, yInicial, xFinal, yFinal));
            if (blanco)
            {
                if (comePieza)
                {
                    if (yFinal - yInicial == 1 && Math.Abs(xFinal - xInicial) == 1) return true;
                }
                else
                {
                    if (xInicial == xFinal && yFinal - yInicial == 1)
                    {
                        return true;
                    }
                    if (xInicial == xFinal && yFinal - yInicial == 2 && yInicial == 1)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (comePieza)
                {
                    if (yFinal - yInicial == -1 && Math.Abs(xFinal - xInicial) == 1) return true;
                }
                else
                {
                    if (xInicial == xFinal && yFinal - yInicial == -1)
                    {
                        return true;
                    }
                    if (xInicial == xFinal && yFinal - yInicial == -2 && yInicial == 6)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool torre(int xInicial, int yInicial, int xFinal, int yFinal)
        {
            if (xInicial == xFinal || yInicial == yFinal) return true;
            return false;
        }

        public bool caballo(int xInicial, int yInicial, int xFinal, int yFinal)
        {
            if((Math.Abs(xInicial - xFinal) == 2 && Math.Abs(yInicial - yFinal) == 1) ||
                (Math.Abs(yInicial - yFinal) == 2 && Math.Abs(xInicial - xFinal) == 1)) return true;
            return false;
        }

        public bool afil(int xInicial, int yInicial, int xFinal, int yFinal)
        {
            if (Math.Abs(xInicial - xFinal) == Math.Abs(yInicial - yFinal)) return true;
            return false;
        }

        public bool dama(int xInicial, int yInicial, int xFinal, int yFinal)
        {
            if((xInicial == xFinal || yInicial == yFinal) ||
                (Math.Abs(xInicial - xFinal) == Math.Abs(yInicial - yFinal))) return true;
            return false;
        }

        public bool rey(int xInicial, int yInicial, int xFinal, int yFinal)
        {
            if((Math.Abs(xInicial - xFinal) == 1 && Math.Abs(yInicial - yFinal) < 2) || 
                (Math.Abs(yInicial - yFinal) == 1 && (Math.Abs(xInicial - xFinal) < 2))) return true;
            return false;
        }
    }
}
