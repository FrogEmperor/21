using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_juego
{
    class Mano
    {
        public List<Carta> mano { get; set; }
        public Mano()
        {
            mano = new List<Carta>();
        }
        public void RecibirCarta(Carta c)
        {
            mano.Add(c);
        }
        public int SumaMano()
        {
            int total = 0;
            int aces = 0;
            foreach (Carta c in mano)
            {
                if (c.Valor == 11)
                {
                    aces++;
                }
                total += c.Valor;
            }
            while (total>21&&aces>1)
            {
                total -= 10;
                aces--;
            }
            return total;
        }
    }
}
