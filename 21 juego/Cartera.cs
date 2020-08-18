using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace _21_juego
{
    class Cartera
    {
        public List<Ficha> fichas5 { get; set; }
        public List<Ficha> fichas10 { get; set; }
        public List<Ficha> fichas20 { get; set; }
        public Cartera()
        {
            this.fichas5 = new List<Ficha>();
            this.fichas10 = new List<Ficha>();
            this.fichas20 = new List<Ficha>();
        }
        public int Dinero()
        {
            int suma = 0;
            for (int i = 0; i < fichas5.Count; i++)
            {
                suma += 5;
            }
            for (int i = 0; i < fichas10.Count; i++)
            {
                suma += 10;
            }
            for (int i = 0; i < fichas20.Count; i++)
            {
                suma += 20;
            }
            return suma;
        }
        public void ImprimirCartera(Canvas canvasF5, Canvas canvasF10, Canvas canvasF20)
        {
            int posX5 = 0;
            int posX10 = 0;
            int posX20 = 0;
            foreach (Ficha ficha in fichas5)
            {
                ficha.Dibujate(canvasF5, posX5, 0);
                posX5 += 20;
            }
            foreach (Ficha ficha in fichas10)
            {
                ficha.Dibujate(canvasF10, posX10, 0);
                posX10 += 20;

            }
            foreach (Ficha ficha in fichas20)
            {
                ficha.Dibujate(canvasF20, posX20, 0);
                posX20 += 20;
            }
        }
    }
}
