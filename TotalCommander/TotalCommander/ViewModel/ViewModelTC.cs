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
    class ViewModelTC
    {
        public ViewModelPanel VMLeft { get; set; }
        public ViewModelPanel VMRight { get; set; }
        public ViewModelTC()
        {
            VMLeft = new ViewModelPanel();
            VMRight = new ViewModelPanel();
        }
        //Kopiowanie tutaj
    
    
        
    
    }


}
