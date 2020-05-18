using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;


namespace TotalCommander.ViewModel
{
    using BaseClass;
    using System.Windows.Controls.Primitives;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Diagnostics;
    using TotalCommander.Model;
    class ViewModelPanel : ViewModelBase
    {
        public ObservableCollection<string> oc = new ObservableCollection<string>();
        //Do wczytania drivesList w ListBox
        //Wczytanie wszystkich dysków logicznych na komputerze
        public string CurrentDrive { get; set; }
        //Wczytuje pobrany string wybrany w comboBoxDisk
        public static string Name { get; set; }
        public string[] ListOfCurrentDrive
        {
            get
            {
                return CurrentDrives;
            }
        }
        public string[] CurrentDrives
        {
            get
            {
                string[] lst = new string[Operating.drivesList.Length];
                for (int i = 0; i < lst.Length; i++)
                    lst[i] = Operating.drivesList[i];
                return lst;
            }
        }

        //Wyświetlenie dysków w comboBox
        private ICommand _clear = null;
        public ICommand Clear
        {
            get
            {
                if (_clear == null)
                {
                    _clear = new RelayCommand(
                        arg => { Path = CurrentDrive; Oc = Operating.ReturnOc(CurrentDrive); },

                        arg => true

                        );
                }
                return _clear;
            }
        }

        //To jest przyczepione do comboBox i narazie nic nie robi - jest testowe czy odczytuje mi poprawnie string wybranego dysku
        public ObservableCollection<string> Oc
        {
            get { return oc; }
            set
            {
                oc = value;
                onPropertyChanged(nameof(Oc));
            }
        }
        //Odwołuje się bezpośrednio do listy widniejącej w aplikacji
        public ViewModelPanel()
        {
            //Oc = Operating.ReturnOc(Path);
        }
        //Do zmiany

        private string path;
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                onPropertyChanged(nameof(Path));
            }
        }
        //Odwołanie do textBlock, które pokazuje ścieżkę
        public static string currentPath;
        public string CurrentPath
        {
            get { return currentPath; }
            set
            {
                currentPath = value;
                if (currentPath != null)
                {
                    Path = currentPath;
                }
                onPropertyChanged(nameof(CurrentPath));
            }
        }
        //Jak wybierze mi daną ścieżkę to się powinien zaaktualizować nową textBlock
        private ICommand _newList = null;
        public ICommand NewList
        {
            get
            {
                if (_newList == null)
                {
                    _newList = new RelayCommand(
                        arg => { Oc = Operating.ReturnOc(Path); },

                        arg => true

                        );
                }
                return _newList;
            }
        }

        //Druga część okna
        public ObservableCollection<String> ocTo = new ObservableCollection<String>();
        //Do wczytania ListOfDisk w ListBox
        //Wczytanie wszystkich dysków logicznych na komputerze
        public string CurrentDiskTo { get; set; }
        //Wczytuje pobrany string wybrany w comboBoxDisk
        public static string NazwaTo { get; set; }
        public string[] ListOfCurrentDiskTo
        {
            get
            {
                return CurrentsDiskTo;
            }
        }
        public string[] CurrentsDiskTo
        {
            get
            {
                string[] res = new string[Operating.drivesList.Length];
                for (int i = 0; i < res.Length; i++)
                    res[i] = Operating.drivesList[i];
                return res;
            }
        }
        //Wyświetlenie dysków w comboBox
        private ICommand _clearTo = null;
        public ICommand ClearTo
        {
            get
            {
                if (_clearTo == null)
                {
                    _clearTo = new RelayCommand(
                        arg => { PathTo = CurrentDiskTo; OcTo = Operating.ReturnOc(CurrentDiskTo); },

                        arg => true

                        );
                }
                return _clearTo;
            }
        }
        //To jest przyczepione do comboBox i narazie nic nie robi - jest testowe czy odczytuje mi poprawnie string wybranego dysku
        public ObservableCollection<String> OcTo
        {
            get { return ocTo; }
            set
            {
                ocTo = value;
                onPropertyChanged(nameof(OcTo));
            }
        }
        //Odwołuje się bezpośrednio do listy widniejącej w aplikacji
        private string pathTo;
        public string PathTo
        {
            get { return pathTo; }
            set
            {
                pathTo = value;
                onPropertyChanged(nameof(PathTo));
            }
        }
        //Odwołanie do textBlock, które pokazuje ścieżkę - nie działa :(
        public static String currentPathTo;
        public String CurrentPathTo
        {
            get { return currentPathTo; }
            set
            {
                currentPathTo = value;
                if (currentPathTo != null)
                {
                    if (Operating.IsFolder(currentPathTo) == true)
                    {
                        PathTo = Operating.IfFolder(currentPathTo);
                    }
                    else PathTo = currentPathTo;
                }
                onPropertyChanged(nameof(CurrentPathTo));
            }
        }
        //Jak wybierze mi daną ścieżkę to się powinien zmienić textBlock?
        private ICommand _newListTo = null;
        public ICommand NewListTo
        {
            get
            {
                if (_newListTo == null)
                {
                    _newListTo = new RelayCommand(
                        arg => { OcTo = Operating.ReturnOc(@PathTo); },

                        arg => true

                        );
                }
                return _newListTo;
            }
        }

        private ICommand _copy = null;
        public ICommand Copy
        {
            get
            {
                if (_copy == null)
                {
                    _copy = new RelayCommand(
                        arg => { const string quote = "\""; MessageBox.Show("copy " + quote + Path + quote + " " + quote + PathTo + quote); string commend = "copy " + quote + Path + quote + " " + quote + PathTo + quote; ExecuteCommand(commend); OcTo = Operating.ReturnOc(@PathTo); },

                        arg => true

                        );
                }
                return _copy;
            }
        }
        static void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            MessageBox.Show("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            MessageBox.Show("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            MessageBox.Show("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }


        //Dyski logiczne - są też napędy!
        //Jak dostosawać okno do ilości plików? - vertical scrollbar nad obiektem który ma być skrolowany
        //Nie wyświetlają się nazwy w plikach? Dlaczego?
    }
}
