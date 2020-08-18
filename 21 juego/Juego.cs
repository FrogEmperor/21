using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _21_juego
{
    class Juego
    {
        public Jugador jugador { get; set; }
        public Baraja baraja { get; set; }
        public Casa casa { get; set; }
        public Juego()
        {
            this.jugador = new Jugador();
            this.casa = new Casa();
            this.baraja = new Baraja(); 
        }
        public void empezar(Canvas canvasJugador, Canvas canvasCasa, bool continuar, Canvas canvasF5, Canvas canvasF10, Canvas canvasF20)
        {
            this.jugador.mano.mano.Clear();
            this.casa.mano.mano.Clear();
            if (!continuar) {
                this.jugador.IniciarCartera();
                this.baraja.Reiniciar();
            }
            canvasF5.Children.Clear();
            canvasF10.Children.Clear();
            canvasF20.Children.Clear();
            jugador.cartera.ImprimirCartera(canvasF5,canvasF10, canvasF20);
            Carta salio;
            salio = baraja.RepartirCarta();
            jugador.mano.RecibirCarta(salio);
            salio.Dibujate(canvasJugador, 20, 20);
            salio = baraja.RepartirCarta();
            jugador.mano.RecibirCarta(salio);
            salio.Dibujate(canvasJugador, 60, 20);

            salio = baraja.RepartirCarta();
            casa.mano.RecibirCarta(salio);
            salio.Dibujate(canvasCasa, 300, 20);
            salio = baraja.RepartirCarta();
            casa.mano.RecibirCarta(salio);
            salio.DibujateBack(canvasCasa, 260, 20);
        }
        public void ResultadoPartida(Canvas canvasF5, Canvas canvasF10, Canvas canvasF20, Canvas canvasCF5, Canvas canvasCF10, Canvas canvasCF20)
        {
            int manoJugador = jugador.mano.SumaMano(); 
            int manoCasa = casa.mano.SumaMano();
            string jugadorGano = "PERDOR";
            if (manoJugador > 21 && manoCasa > 21)
            {
                jugadorGano = "EMPATE";
            }
            else if (manoJugador > 21)
            {
                jugadorGano = "PERDEDOR";
            }
            else if (manoCasa > 21)
            {
                jugadorGano = "GANADOR";
            }
            else if (manoJugador > manoCasa)
            {
                jugadorGano = "GANADOR";
            }
            else if (manoJugador == manoCasa)
            {
                jugadorGano = "EMPATE";
            }

            if (jugadorGano == "GANADOR")
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < this.casa.cartera.fichas5.Count; i++)
                    {
                        jugador.cartera.fichas5.Add(this.casa.cartera.fichas5[i]);
                    }
                    for (int i = 0; i < this.casa.cartera.fichas10.Count; i++)
                    {
                        jugador.cartera.fichas10.Add(this.casa.cartera.fichas10[i]);
                    }
                    for (int i = 0; i < this.casa.cartera.fichas20.Count; i++)
                    {
                        jugador.cartera.fichas20.Add(this.casa.cartera.fichas20[i]);
                    }
                }
            }
            else if (jugadorGano == "EMPATE") {
                for (int i = 0; i < this.casa.cartera.fichas5.Count; i++)
                {
                    jugador.cartera.fichas5.Add(this.casa.cartera.fichas5[i]);
                }
                for (int i = 0; i < this.casa.cartera.fichas10.Count; i++)
                {
                    jugador.cartera.fichas5.Add(this.casa.cartera.fichas10[i]);
                }
                for (int i = 0; i < this.casa.cartera.fichas20.Count; i++)
                {
                    jugador.cartera.fichas20.Add(this.casa.cartera.fichas20[i]);
                }
            }
            this.casa.cartera.fichas5.Clear();
            this.casa.cartera.fichas10.Clear();
            this.casa.cartera.fichas20.Clear();
            canvasCF5.Children.Clear();
            canvasCF10.Children.Clear();
            canvasCF20.Children.Clear();
            this.jugador.cartera.ImprimirCartera(canvasF5, canvasF10, canvasF20);
        }
        public void DarCarta(bool EsJugador, Canvas dondeImprimir, int Xpos)
        {
            Carta salio;
            for (int i = 0; i < baraja.Cartas.Count; i++)
            {
                if (!baraja.Cartas[i].Usado)
                {
                    if (EsJugador)
                    {
                        salio = baraja.RepartirCarta();
                        salio.Dibujate(dondeImprimir, Xpos, 20);
                        this.jugador.mano.RecibirCarta(salio);
                    }
                    else
                    {
                        salio = baraja.RepartirCarta();
                        salio.DibujateBack(dondeImprimir, Xpos, 20);
                        this.casa.mano.RecibirCarta(salio);
                    }
                    break;
                }
            }  
        }
        public void Apuesta(Ficha ficha, Canvas canvasF5, Canvas canvasF10, Canvas canvasF20, Canvas canvasCF5, Canvas canvasCF10, Canvas canvasCF20)
        {
            if (ficha.valor == 5)
            {
                if (this.jugador.cartera.fichas5.Count !=0) {
                    this.casa.cartera.fichas5.Add(ficha);
                    this.jugador.cartera.fichas5.RemoveAt(jugador.cartera.fichas5.Count - 1);
                }
            }
            else if (ficha.valor == 10)
            {
                if (this.jugador.cartera.fichas10.Count != 0)
                {
                    this.casa.cartera.fichas10.Add(ficha);
                    this.jugador.cartera.fichas10.RemoveAt(jugador.cartera.fichas10.Count - 1);
                }
            }
            else if (ficha.valor == 20)
            {
                if (this.jugador.cartera.fichas20.Count != 0)
                {
                    this.casa.cartera.fichas20.Add(ficha);
                    this.jugador.cartera.fichas20.RemoveAt(jugador.cartera.fichas20.Count - 1);
                }
            }
            canvasF5.Children.Clear();
            canvasF10.Children.Clear();
            canvasF20.Children.Clear();
            jugador.cartera.ImprimirCartera(canvasF5,canvasF10,canvasF20);
            casa.cartera.ImprimirCartera(canvasCF5, canvasCF10, canvasCF20);
        }

    }
}
