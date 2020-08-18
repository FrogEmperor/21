using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_juego
{
    class Jugador
    {
        public Mano mano { get; set; }
        public Cartera cartera { get; set; }
        public Jugador()
        {
            this.mano = new Mano();
            this.cartera = new Cartera();
            IniciarCartera();
        }
        public void IniciarCartera()
        {
            this.cartera.fichas5.Clear();
            this.cartera.fichas10.Clear();
            this.cartera.fichas20.Clear();
            for (int i = 0; i < 10; i++)
            {
                Ficha f;
                if (i < 5)
                {
                    f = new Ficha(5);
                    this.cartera.fichas5.Add(f);
                }
                else if (i < 8)
                {
                    f = new Ficha(10);
                    this.cartera.fichas10.Add(f);
                }
                else
                {
                    f = new Ficha(20);
                    this.cartera.fichas20.Add(f);
                }
                
            }
        }
    }
}
