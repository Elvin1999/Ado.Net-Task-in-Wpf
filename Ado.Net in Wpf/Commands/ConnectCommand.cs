using Ado.Net_in_Wpf.Entities;
using Ado.Net_in_Wpf.ViewModels;
using Ado.Net_in_Wpf.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ado.Net_in_Wpf.Commands
{
   public class ConnectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public DataBaseConnectionViewModel DBConnectionVM { get; set; }
        public DatabaseConnection DatabaseConnection { get; set; }
        public StudentViewModel StudentViewModel { get; private set; }

        public ConnectCommand(DataBaseConnectionViewModel DBConnectionVM)
        {
            this.DBConnectionVM = DBConnectionVM;
            DatabaseConnection = DBConnectionVM.DatabaseConnection;
            DatabaseConnection.IntergratedSecurity = true;//it is tempreture
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DatabaseConnection = DBConnectionVM.DatabaseConnection;
            Config config = new Config(DatabaseConnection);
            config.SeriailizeToJson();
            StudentViewModel = new StudentViewModel();

            config.DeserializeFromJson();
            App.DB = new DataAccessLayer(config.GetConnectionElement());
            if (App.DB.GetStudents() != null)
            {
                StudentViewModel.AllStudents = new ObservableCollection<Student>(App.DB.GetStudents());
                StudentView studentView = new StudentView(StudentViewModel);
                studentView.ShowDialog();
            }
            else
            {
                MessageBoxResult messageBox1 = MessageBox.Show("No");
                ////////////////////after open DBConnectionView
                DatabaseConnectionView databaseConnectionView = new DatabaseConnectionView(DBConnectionVM);
                databaseConnectionView.ShowDialog();
                DatabaseConnection databaseConnection = new DatabaseConnection()
                {//example
                    //DataBaseName = "StudentDb",
                    //DataSource = @"DOCUMENTS-ПК\MYSQLSEjhnknnjRVERMSSQL",
                    //IntergratedSecurity = true,
                    //UserId = "",
                    //Password = ""
                };

                Config config1 = new Config(databaseConnection);

                config1.SeriailizeToJson();
            }
        }
    }
}
