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
using System.Windows.Shapes;

namespace TotalCommander.View
{
    /// <summary>
    /// Logika interakcji dla klasy Obiekt.xaml
    /// </summary>
    public partial class Obiekt : UserControl
    {
        public Obiekt()
        {
            InitializeComponent();
        }

        #region Własność zależna
        /// <summary>
        /// W taki sposób tworzymy własność, która będzie się wiązać w MVVM-ie
        /// </summary>
        //do tej własności odwołujemy się z zewnątrz
        public string PathObiekt
        {
            get { return (string)GetValue(PathReg); }
            set { SetValue(PathReg, value); }
        }

        public static readonly DependencyProperty PathReg = DependencyProperty.Register(
           nameof(PathObiekt), typeof(string), typeof(Obiekt), new FrameworkPropertyMetadata(null));
        #endregion

        #region Zdarznie własne zarejestrowane
        //rejestracja zdarzenia tak, żeby możliwe było jego bindowanie
        public static readonly RoutedEvent MojeZdarzenieZarejestrowane =
        EventManager.RegisterRoutedEvent(nameof(MojeZdarzenie),
                     RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                     typeof(Obiekt));

        //definicja zdarzenia MojeZdarzenie
        public event RoutedEventHandler MojeZdarzenie
        {
            add { AddHandler(MojeZdarzenieZarejestrowane, value); }
            remove { RemoveHandler(MojeZdarzenieZarejestrowane, value); }
        }

        //Metoda pomocnicza wywołująca zdarzenie
        //przy okazji metoda ta tworzy obiekt argument przekazywany przez to zdarzenie
        void RaiseMojeZdarzenie()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(MojeZdarzenieZarejestrowane);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }
        #endregion

    }
}
