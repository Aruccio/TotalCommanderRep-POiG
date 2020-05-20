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
using TotalCommander.Model;

namespace TotalCommander.View
{
    /// <summary>
    /// Logika interakcji dla klasy Panel.xaml
    /// </summary>
    public partial class Panel : UserControl
    {
        public Panel()
        {
            InitializeComponent();
        }
        public string PathPanel
        {
            get { return (string)GetValue(PathReg); }
            set { SetValue(PathReg, value); }
        }
        public static readonly DependencyProperty PathReg = DependencyProperty.Register(
           nameof(PathPanel), typeof(string), typeof(Panel), new FrameworkPropertyMetadata(null));
        //Ścieżka obowiązująca
        public string PanelDrive
        {
            get { return (string)GetValue(DriveReg); }
            set { SetValue(DriveReg, value); }
        }
        public static readonly DependencyProperty DriveReg = DependencyProperty.Register(
           nameof(PanelDrive), typeof(string), typeof(Panel), new FrameworkPropertyMetadata(null));
        //Dysk wybrany w comboBox
        public string[] PanelDrives
        {
            get { return (string[])GetValue(DrivesReg); }
            set { SetValue(DrivesReg, value); }
        }
        public static readonly DependencyProperty DrivesReg = DependencyProperty.Register(
           nameof(PanelDrives), typeof(string[]), typeof(Panel), new FrameworkPropertyMetadata(null));
        //Załadowanie listy dysków w ComboBox


        public static readonly RoutedEvent MojeZdarzenieZarejestrowane =
        EventManager.RegisterRoutedEvent(nameof(MyEvent),
                     RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                     typeof(Panel));

        //definicja zdarzenia MyEvent
        public event RoutedEventHandler MyEvent
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

        private void comboBoxOfDrives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseMojeZdarzenie();
        }





    }
}
