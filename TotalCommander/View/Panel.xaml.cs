using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
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

        #region Własności zależne
        public string CopyDirectoryOrFile
        {
            get { return (string)GetValue(CDORReg); }
            set { SetValue(CDORReg, value); }
        }
        public static readonly DependencyProperty CDORReg = DependencyProperty.Register(
           nameof(CopyDirectoryOrFile), typeof(string), typeof(Panel), new FrameworkPropertyMetadata(null));
        //Ścieżka kopiowanego pliku
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

        public ObservableCollection<string> PanelOC
        {
            get { return (ObservableCollection<string>)GetValue(OCReg); }
            set { SetValue(OCReg, value); }
        }
        public static readonly DependencyProperty OCReg = DependencyProperty.Register(
           nameof(PanelOC), typeof(ObservableCollection<string>), typeof(Panel), new FrameworkPropertyMetadata(null));
        //Lista OC

        public string PanelListPath
        {
            get { return (string)GetValue(ListPathReg); }
            set { SetValue(ListPathReg, value); }
        }
        public static readonly DependencyProperty ListPathReg = DependencyProperty.Register(
           nameof(PanelListPath), typeof(string), typeof(Panel), new FrameworkPropertyMetadata(null));
        //Ścieżka pobrana z listy
        #endregion

        #region Zdarznie własne zarejestrowane
        public static readonly RoutedEvent comboBoxSelected =
        EventManager.RegisterRoutedEvent(nameof(ComboBoxSelected),
                     RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                     typeof(Panel));
        public event RoutedEventHandler ComboBoxSelected
        {
            add { AddHandler(comboBoxSelected, value); }
            remove { RemoveHandler(comboBoxSelected, value); }
        }
        void RaiseComboBoxSelected()
        {
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(Panel.comboBoxSelected);
            RaiseEvent(newEventArgs);
        }
        private void comboBoxOfDrives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseComboBoxSelected();
        }
        //Definicja zdarzenia odpowiedzialnego za wybranie danego dysku w liście comboBox

        public static readonly RoutedEvent updatedNewList =
        EventManager.RegisterRoutedEvent(nameof(UpdatedNewList),
                 RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                 typeof(Panel));
        public event RoutedEventHandler UpdatedNewList
        {
            add { AddHandler(updatedNewList, value); }
            remove { RemoveHandler(updatedNewList, value); }
        }
        void RaiseUpdatedNewList()
        {
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(Panel.updatedNewList);
            RaiseEvent(newEventArgs);
        }
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RaiseUpdatedNewList();
        }
        //Zdefiniowanie zdarzenia odpowiedzialnego za aktualizację listy obowiązującej ścieżki

        public static readonly RoutedEvent newPathToCopyFile =
        EventManager.RegisterRoutedEvent(nameof(NewPathToCopyFile),
                 RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                 typeof(Panel));
        public event RoutedEventHandler NewPathToCopyFile
        {
            add { AddHandler(newPathToCopyFile, value); }
            remove { RemoveHandler(newPathToCopyFile, value); }
        }
        void RaiseNewPathToCopyFile()
        {
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(Panel.newPathToCopyFile);
            RaiseEvent(newEventArgs);
        }
        private void ListBox_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            RaiseNewPathToCopyFile();
        }
        //Zdefiniowanie zdarzenia odnoszącego się do zapamiętania plików do kopiowania
        #endregion


    }
}
