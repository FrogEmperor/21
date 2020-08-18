using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_juego
{
    class Casa
    {
        public Mano mano { get; set; }
        public Cartera cartera { get; set; }
        public Casa()
        {
            this.mano = new Mano();
            this.cartera = new Cartera();
        }

    }
}
