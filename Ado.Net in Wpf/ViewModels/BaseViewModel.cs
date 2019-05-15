using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net_in_Wpf.ViewModels
{
   public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyCanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this,e);
        }
    }
}

