using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class Jugador
    {
        private bool jaque;
        private bool jaqueMate;
        private bool enroqueCorto;
        private bool enroqueLargo;
        private bool local;
        private bool blanco;

        public Jugador(bool blanco, bool local)
        {
            this.local = local;
            this.blanco = blanco;
        }

        public void setJaque(bool jaque)
        {
            this.jaque = jaque;
        }

        public void setJaqueMate(bool jaqueMate)
        {
            this.jaqueMate = jaqueMate;
        }

        public void setEnroqueCorto(bool enroqueCorto)
        {
            this.enroqueCorto = enroqueCorto;
        }

        public void setEnroqueLargo(bool enroqueLargo)
        {
            this.enroqueLargo = enroqueLargo;
        }
    }
}
