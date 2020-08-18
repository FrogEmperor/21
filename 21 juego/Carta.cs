using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace _21_juego
{
    class Carta
    {
        public int Valor { get; set; }
        public string ImagenSource { get; set; }
        public bool Usado { get; set; }
        public Carta(string ImagenSource, int Valor)
        {
            this.Valor = Valor;
            this.ImagenSource = ImagenSource;
            this.Usado = false;
        }
        public void Dibujate(Canvas espacioCarta, int posX, int posY)
        {
            System.Windows.Controls.Image i = new Image();
            i.Source = new BitmapImage(new Uri(this.ImagenSource, UriKind.Relative));
            i.Width = 180;
            i.Height = 250;
            espacioCarta.Children.Add(i);
            Canvas.SetLeft(i, posX);
            Canvas.SetTop(i, posY);
        }
        public void DibujateBack(Canvas espacioCarta, int posX, int posY)
        {
            System.Windows.Controls.Image i = new Image();
            i.Source = new BitmapImage(new Uri(@"Cartas\card_back.png", UriKind.Relative));
            i.Width = 180;
            i.Height = 250;
            espacioCarta.Children.Add(i);
            Canvas.SetLeft(i, posX);
            Canvas.SetTop(i, posY);
        }
    }
}
