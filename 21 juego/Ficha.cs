using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_juego
{
    class Ficha
    {
        public int valor { get; set; }
        public string ImagenSource { get; set; }
        public Ficha(int valor)
        {
            this.valor = valor;
            this.ImagenSource = @"Fichas\ficha" + valor + ".png";
        }
        public void Dibujate(Canvas espacioCarta, int posX, int posY)
        {
            System.Windows.Controls.Image i = new Image();
            i.Source = new BitmapImage(new Uri(this.ImagenSource, UriKind.Relative));
            i.Width = 98;
            i.Height = 98;
            espacioCarta.Children.Add(i);
            Canvas.SetLeft(i, posX);
            Canvas.SetTop(i, posY);
        }
    }
}
