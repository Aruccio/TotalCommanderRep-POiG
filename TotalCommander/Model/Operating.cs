using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Reactive.Linq;
using TotalCommander.ViewModel;
using System.Windows.Forms;
using System.CodeDom.Compiler;

namespace TotalCommander.Model
{
    static class Operating
    {
        #region Dyski
        public static string[] drivesList = GetDrives();
        //public static String[] List = DriveInfo.GetDrives();
        public static string[] GetDrives()
        {
            var drivesList = new List<string>();
            var drives = DriveInfo.GetDrives();
            foreach (var d in drives)
            {
                if (d.IsReady) drivesList.Add(d.ToString());
            }
            return drivesList.ToArray();
        }
        //Pobiera aktualne dyski posiadające pliki i foleru
        #endregion

        public static ObservableCollection<string> ReturnOc(string path, string originalPath, string currentDrive)
        {

            ObservableCollection<string> oc = new ObservableCollection<string>();
            try
            {
                string currentPath;
                if (currentDrive != originalPath) oc.Add("..");

                string[] subFolders = Directory.GetDirectories(originalPath);
                for (int i = 0; i < subFolders.Length; i++)
                {
                    currentPath = subFolders[i];

                    string temp = "<D> " + Path.GetFileName(currentPath);
                    oc.Add(temp);//currentPath);
                    

                }
                string[] Files = Directory.GetFiles(originalPath);
                for (int i = 0; i < Files.Length; i++)
                {
                    currentPath = Files[i];
                    oc.Add(Path.GetFileName(currentPath));
                }

                return oc;
            }
            catch
            {
                ObservableCollection<string> empty = new ObservableCollection<string>();
                if (currentDrive != originalPath) empty.Add("..");
                return empty;
            }
        }
        //Funkcja odpowiadająca za wygląd plików i folderów na liście aplikacji
        public static void CopyFile(string path, string path2, string path3)
        {
            if (path != "" && path2 != "")
            {
                if (path3[0] == '<')
                {
                    try
                    {
                        if (path2[path2.Length - 1] != '\\')
                        {
                            File.Copy(path, path2 + "\\" + Path.GetFileName(path));
                        }
                        else
                        {
                            File.Copy(path, path2 + Path.GetFileName(path));
                        }

                    }
                    catch (IOException copyError)
                    {
                        MessageBox.Show(copyError.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Twoja docelowa ścieżka jest ścieżką do pliku! Nie jest to folder!");
                }
            }
            else
            {
                MessageBox.Show("Ścieżki nie mogą być puste!");
            }
        }
        //Funkcja Copy

        public static string ReturnFileName(string OriginalPath)
        {
            return Path.GetFileName(OriginalPath);
        }
    }


}

