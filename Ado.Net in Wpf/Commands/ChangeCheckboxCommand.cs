using Ado.Net_in_Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ado.Net_in_Wpf.Commands
{
   public class ChangeCheckboxCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public DataBaseConnectionViewModel DataBaseConnectionViewModel { get; set; }
        public ChangeCheckboxCommand(DataBaseConnectionViewModel DbVM)
        {
            this.DataBaseConnectionViewModel = DbVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var res = DataBaseConnectionViewModel.State;
            if (res != 1)
            {
                DataBaseConnectionViewModel.State = 1;
            }
            else
            {
                DataBaseConnectionViewModel.State = 2;
            }
        }
    }
}
