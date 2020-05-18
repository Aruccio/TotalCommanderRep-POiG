﻿using System;
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


namespace TotalCommander.Model
{
    static class Operating
    {

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
        public static ObservableCollection<string> ReturnOc(string path)
        {
            ObservableCollection<string> oc = new ObservableCollection<string>();
            try
            {
                string currentPath;
                if(!oc.Contains(Path.GetDirectoryName(path))) oc.Add(Path.GetDirectoryName(path));
                string[] subFolders = Directory.GetDirectories(path);
                for (int i = 0; i < subFolders.Length; i++)
                {
                    currentPath = subFolders[i];
                    oc.Add(currentPath);
                }

                string[] Files = Directory.GetFiles(path);
                for (int i = 0; i < Files.Length; i++)
                {
                    currentPath = Files[i];
                    oc.Add(currentPath);
                }

                return oc;
            }
            catch
            {
                ObservableCollection<string> empty = new ObservableCollection<string>();
                if (!empty.Contains(Path.GetDirectoryName(path))) empty.Add(Path.GetDirectoryName(path));
                empty.Add("Pusto");
                return empty;
            }
        }
        public static bool IsFolder(string path)
        {
            bool isFolder = false;
            MessageBox.Show(path.Length.ToString());
            if (path.Length > 4)
            {
                string subPath = path.Substring(0, 4);
                if (subPath == "<D> ")
                {
                    isFolder = true;
                    MessageBox.Show("True");
                    return isFolder;
                }
                else
                {
                    MessageBox.Show("False");
                    return isFolder;
                }
            }
            else
            {
                MessageBox.Show("false");
                return isFolder;
            }
        }
        //Funkcja sprawdzająca, czy dana ścieżka jest lokalizacją dla folderu
        public static string IfFolder(string path)
        {
            string subPath = path.Substring(4, path.Length - 1);
            MessageBox.Show(subPath);
            return subPath;
        }
        //Jakie są dyski i foldery, lokalizacja root? 
    }


}
