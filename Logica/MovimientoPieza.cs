using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class MovimientoPieza
    {
        public bool peon(int xInicial, int yInicial, int xFinal, int yFinal, bool blanco, bool comePieza)
        {
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
                    if (xInicial == xFinal && yFinal - yInicial == 2 && xInicial == 2)
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
                    if (xInicial == xFinal && yFinal - yInicial == -2 && xInicial == 7)
                    {
                        return true;
                    }
                }
            }
            return true;
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
            if(Math.Abs(xInicial - xFinal) == 1 || Math.Abs(yInicial - yFinal) == 1) return true;
            return false;
        }
    }
}
