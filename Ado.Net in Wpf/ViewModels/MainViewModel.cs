using Ado.Net_in_Wpf.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net_in_Wpf.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public StartCommand StartCommand => new StartCommand(this);

    }
}




