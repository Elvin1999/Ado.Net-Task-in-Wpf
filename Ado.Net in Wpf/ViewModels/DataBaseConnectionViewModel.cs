using Ado.Net_in_Wpf.Commands;
using Ado.Net_in_Wpf.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net_in_Wpf.ViewModels
{
    public class DataBaseConnectionViewModel : BaseViewModel
    {
        public DataBaseConnectionViewModel()
        {
            DatabaseConnection = new DatabaseConnection();
        }
        public ConnectCommand ConnectCommand => new ConnectCommand(this);
        private DatabaseConnection databaseConnection;
        public DatabaseConnection DatabaseConnection
        {
            get
            {
                return databaseConnection;
            }
            set
            {
                databaseConnection = value;
                OnPropertyCanged(new PropertyChangedEventArgs(nameof(DatabaseConnection)));
            }
        }
    }
}
