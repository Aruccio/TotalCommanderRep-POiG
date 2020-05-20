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
        string x = "";
        //Pomocniczy string

        string copyFilePath = "";
        public string CopyFilePath
        {
            get { return copyFilePath; }
            set
            {
                copyFilePath = value;
                onPropertyChanged(nameof(CopyFilePath));
            }
        }
        //Ścieżka kopiowanego pliku

        string currentDrive = "";
        public string CurrentDrive
        {
            get { return currentDrive; }
            set
            {
                currentDrive = value;
                onPropertyChanged(nameof(CurrentDrive));
            }
        }
        //Obsługiwany dysk

        public string PathX { get; set; }
        //Wczytuje z listy nazwę wybranego pliku/folderu

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
        
        public ObservableCollection<string> oc = new ObservableCollection<string>();
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
        //Odwołanie do textBlock, które pokazuje ścieżkę. Aktualna ścieżka do plików i folderów

        public string currentPath;
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

        #region Zdarzenia w Panelu
        private ICommand _listAfterSelectingDrive = null;
        public ICommand ListAfterSelectingDrive
        {
            get
            {
                if (_listAfterSelectingDrive == null)
                {
                    _listAfterSelectingDrive = new RelayCommand(

                        arg => {
                            PathX = CurrentDrive; OriginalPath = CurrentDrive;
                            Oc = Operating.ReturnOc(CurrentDrive, CurrentDrive, CurrentDrive);
                        },

                        arg => true

                        );
                }
                return _listAfterSelectingDrive;
            }
        }
        //Lista aktualizująca pliki i foldery po wybraniu odpowiedniego dysku w comboBox

        private ICommand _newPathToCopyFile = null;
        public ICommand NewPathToCopyFile
        {
            get
            {
                if (_newPathToCopyFile == null)
                {
                    _newPathToCopyFile = new RelayCommand(
                        arg => {
                            if (PathX != "..")
                            {                               
                                if (PathX[0] == '<')
                                {
                                    x = PathX.Substring(4, PathX.Length - 4);
                                    if (OriginalPath.Length != 0)
                                    {
                                        if (Operating.ReturnFileName(OriginalPath) != x && OriginalPath[OriginalPath.Length - 1] != '\\')
                                            CopyFilePath = OriginalPath + "\\" + x;
                                        if (Operating.ReturnFileName(OriginalPath) != x && OriginalPath[OriginalPath.Length - 1] == '\\')
                                            CopyFilePath = OriginalPath + x;
                                    }
                                }
                                else
                                {
                                    x = PathX;
                                    if (Operating.ReturnFileName(OriginalPath) != x && OriginalPath[OriginalPath.Length - 1] != '\\')
                                        CopyFilePath = OriginalPath + "\\" + x;
                                    if (Operating.ReturnFileName(OriginalPath) != x && OriginalPath[OriginalPath.Length - 1] == '\\')
                                        CopyFilePath = OriginalPath + x;
                                }
                            }
                            Oc = Operating.ReturnOc(PathX, OriginalPath, CurrentDrive);
                        },

                        arg => true

                        );
                }
                return _newPathToCopyFile;
            }
        }

        private ICommand _newList = null;
        public ICommand NewList
        {
            get
            {
                if (_newList == null)
                {
                    _newList = new RelayCommand(
                        arg => {
                            if (PathX == "..")
                            {
                                bool isFalse = false;
                                if (OriginalPath[OriginalPath.Length - 1] != '\\' && isFalse==false)
                                {
                                    x = Operating.ReturnFileName(OriginalPath);
                                    OriginalPath = OriginalPath.Substring(0, OriginalPath.Length - x.Length);
                                    isFalse = true;
                                }
                                if (OriginalPath[OriginalPath.Length - 1] == '\\' && isFalse == false && OriginalPath.Length>3)
                                {
                                    OriginalPath = OriginalPath.Substring(0, OriginalPath.Length - 1);
                                    x = Operating.ReturnFileName(OriginalPath);
                                    OriginalPath = OriginalPath.Substring(0, OriginalPath.Length - x.Length);
                                    isFalse = true;
                                }
                                isFalse = false;
                            }
                            else
                            {
                                if (PathX[0] == '<')
                                {
                                    x = PathX.Substring(4, PathX.Length - 4);
                                    if (OriginalPath.Length != 0)
                                    {
                                        if (Operating.ReturnFileName(OriginalPath) != x && OriginalPath[OriginalPath.Length - 1] != '\\')
                                            OriginalPath = OriginalPath + "\\" + x;
                                        if (Operating.ReturnFileName(OriginalPath) != x && OriginalPath[OriginalPath.Length - 1] == '\\')
                                            OriginalPath = OriginalPath + x;
                                    }
                                }
                            }
                            Oc = Operating.ReturnOc(PathX, OriginalPath, CurrentDrive);
                        },

                        arg => true

                        );
                }
                return _newList;
            }
        }
        #endregion
    }
}
