using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _21_juego
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int xJugador = 60;
        int xCasa = 260;
        Juego juego = new Juego();
        
        public MainWindow()
        {
            InitializeComponent();
            mostrarHoldPedir();
            juego.empezar(canvasJugador, canvasCasa, false, canvasF5, canvasF10, canvasF20);
            lblFichasCantidad.Content = "$" + this.juego.jugador.cartera.Dinero();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            turnoJugador();
            if (juego.casa.mano.SumaMano() < 16)
            {
                turnoCasa();
            }
            int manoJugador = this.juego.jugador.mano.SumaMano();
            int manoCasa = this.juego.casa.mano.SumaMano();
            if (manoJugador >= 21 || manoCasa >= 21)
            {
                TerminarTurno();
            }
        }
        private void Button_Click_Hold(object sender, RoutedEventArgs e)
        {
            while (juego.casa.mano.SumaMano() < 16)
            {
                turnoCasa();
            }
            TerminarTurno();
        }
        public void turnoJugador()
        {
            this.xJugador += 40;
            this.juego.DarCarta(true, canvasJugador, xJugador);
        }
        public void turnoCasa()
        {
            this.xCasa -= 40;
            this.juego.DarCarta(false, canvasCasa, xCasa);
        }
        public void TerminarTurno()
        {
            this.juego.ResultadoPartida(canvasF5, canvasF10, canvasF20, canvasCF5, canvasCF10, canvasCF20);
            btnReiniciar.Visibility = Visibility.Visible;
            btnContinuar.Visibility = Visibility.Visible;
            btnHold.Visibility = Visibility.Hidden;
            btnF5.Visibility = Visibility.Hidden;
            btnF10.Visibility = Visibility.Hidden;
            btnF20.Visibility = Visibility.Hidden;
            btnHold.Visibility = Visibility.Hidden;
            imprimirCasa();
            lblFichasCantidad.Content = "$" + this.juego.jugador.cartera.Dinero();
        }
        public void imprimirCasa()
        {
            this.xCasa = 300;
            canvasCasa.Children.Clear();
            for (int i = 0; i < juego.casa.mano.mano.Count; i++)
            {
                juego.casa.mano.mano[i].Dibujate(canvasCasa, xCasa, 20);
                this.xCasa -= 40;
            }
        }
        private void Button_Click_Reiniciar(object sender, RoutedEventArgs e)
        {
            mostrarHoldPedir();
            juego.empezar(canvasJugador, canvasCasa, false, canvasF5, canvasF10, canvasF20);
            lblFichasCantidad.Content = "$" + this.juego.jugador.cartera.Dinero();
        }
        private void Button_Click_Continuar(object sender, RoutedEventArgs e)
        {
            mostrarHoldPedir();
            juego.empezar(canvasJugador, canvasCasa, true, canvasF5, canvasF10, canvasF20);
        }
        public void mostrarHoldPedir()
        {
            this.xJugador = 60;
            this.xCasa = 260;
            canvasCasa.Children.Clear();
            canvasJugador.Children.Clear();
            lblCasa.Content = String.Empty;
            lblJugador.Content = String.Empty;
            btnHold.Visibility = Visibility.Visible;
            btnPedir.Visibility = Visibility.Visible;
            btnReiniciar.Visibility = Visibility.Hidden;
            btnContinuar.Visibility = Visibility.Hidden;
            btnF5.Visibility = Visibility.Visible;
            btnF10.Visibility = Visibility.Visible;
            btnF20.Visibility = Visibility.Visible;
        }
        private void Button_Click_F5(object sender, RoutedEventArgs e)
        {
            Ficha ficha = new Ficha(5);
            juego.Apuesta(ficha, canvasF5, canvasF10, canvasF20, canvasCF5, canvasCF10, canvasCF20);
            lblFichasCantidad.Content = "$" + this.juego.jugador.cartera.Dinero();
        }
        private void Button_Click_F10(object sender, RoutedEventArgs e)
        {
            Ficha ficha = new Ficha(10);
            juego.Apuesta(ficha, canvasF5, canvasF10, canvasF20, canvasCF5, canvasCF10, canvasCF20);
            lblFichasCantidad.Content = "$" + this.juego.jugador.cartera.Dinero();
        }
        private void Button_Click_F20(object sender, RoutedEventArgs e)
        {
            Ficha ficha = new Ficha(20);
            juego.Apuesta(ficha, canvasF5, canvasF10, canvasF20, canvasCF5, canvasCF10, canvasCF20);
            lblFichasCantidad.Content = "$" + this.juego.jugador.cartera.Dinero();
        }
    }
}
