using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TotalCommander.Model;
using TotalCommander.ViewModel.BaseClass;

namespace TotalCommander.ViewModel
{
    class ViewModelTC
    {
        public ViewModelPanel VMLeft { get; set; }
        public ViewModelPanel VMRight { get; set; }
        //Wywołanie dwóch działań do Paneli, którymi będziemy się odwoływać do obiektu Panel
        public ViewModelTC()
        {
            VMLeft = new ViewModelPanel();
            VMRight = new ViewModelPanel();
        }
        private ICommand _copy = null;
        public ICommand Copy
        {
            get
            {
                if (_copy == null)
                {
                    _copy = new RelayCommand(
                        arg => { Operating.CopyFile(VMLeft.CopyFilePath, VMRight.CopyFilePath, VMRight.PathX); },

                        arg => true

                        );
                }
                return _copy;
            }
        }
        //Funkcja kopiuj
    }
}
