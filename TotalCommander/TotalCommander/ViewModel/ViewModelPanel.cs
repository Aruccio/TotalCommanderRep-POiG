using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.IO;


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
        string x = "";

        //Do wczytania drivesList w ListBox
        //Wczytanie wszystkich dysków logicznych na komputerze
        public string CurrentDrive { get; set; }

        public string PathX { get; set; }
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

                        arg => { PathX = CurrentDrive;
                            OriginalPath = CurrentDrive.Substring(0,CurrentDrive.Length-1);
                            MessageBox.Show(OriginalPath);
                            Oc = Operating.ReturnOc(CurrentDrive, CurrentDrive);

                        },

                        arg => true

                        );
                }
                return _clear;
            }
        }


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

        private string originalpath;
        public string OriginalPath
        {
            get { return originalpath; }
            set
            {
                originalpath = value;
                onPropertyChanged(nameof(OriginalPath));
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
                    PathX = currentPath;
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
                        arg => {
                            x = PathX[0] == '<' ? PathX.Substring(4, PathX.Length - 4) : PathX;
                            if (Path.GetFileName(OriginalPath) != x)
                                    OriginalPath = OriginalPath + "\\" +x;

                            MessageBox.Show(OriginalPath);
                            Oc = Operating.ReturnOc(PathX, OriginalPath);
                        },

                        arg => true

                        );
                }
                return _newList;
            }
        }

       
    

        //private ICommand _copy = null;
        //public ICommand Copy
        //{
        //    get
        //    {
        //        if (_copy == null)
        //        {
        //            _copy = new RelayCommand(
        //                arg => { const string quote = "\""; MessageBox.Show("copy " + quote + Path + quote + " " + quote + PathTo + quote); string commend = "copy " + quote + Path + quote + " " + quote + PathTo + quote; ExecuteCommand(commend); OcTo = Operating.ReturnOc(@PathTo); },

        //                arg => true

        //                );
        //        }
        //        return _copy;
        //    }
        //}


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
