using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_juego
{
    class Baraja
    {
        public List<Carta> Cartas { get; }
        public Baraja()
        {
            string[] palo = { "clubs", "hearts" ,"spades","diamonds"};
            string[] valores = { "2","3","4","5","6","7","8","9","10","ace","jack","queen","king"};
            Cartas = new List<Carta>();
            for (int i = 0; i < 52; i++)
            {
                int valor = 0;
                if (i % 13 == 9)
                {
                    valor = 11;
                }
                else if(i%13 > 9)
                {
                    valor = 10;
                }
                else
                {
                    valor = (i % 13) + 2;
                }

                Carta c = new Carta(@"Cartas\" + valores[i % 13] + "_of_" + palo[i/13] + ".png", valor);
                Cartas.Add(c);
            }
        }
        public Carta RepartirCarta()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int indice = rnd.Next(0, Cartas.Count);
            while (Cartas[indice].Usado == true)
            {
                indice = rnd.Next(0, Cartas.Count);
            }
            Carta salio = Cartas[indice];
            Cartas[indice].Usado = true;
            return salio;
        }
        public void Reiniciar()
        {
            for (int i = 0; i < 52; i++)
            {
                Cartas[i].Usado = false;
            }
        }
    }
}
