using Ado.Net_in_Wpf.Entities;
using Ado.Net_in_Wpf.ViewModels;
using Ado.Net_in_Wpf.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace Ado.Net_in_Wpf.Commands
{
    public class StartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel MainViewModel { get; set; }
        public StudentViewModel StudentViewModel { get; set; }
        public StartCommand(MainViewModel mainViewModel)
        {
            this.MainViewModel = MainViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            FileInfo fileInfo = new FileInfo("config.json");
            if (fileInfo.Exists)
            {
                MessageBoxResult messageBox = MessageBox.Show("Okay");
                StudentViewModel = new StudentViewModel();
                StudentView studentView = new StudentView(StudentViewModel);
                studentView.ShowDialog();
                //StudentViewModel.AllStudents = new ObservableCollection<Student>(App.DB.GetStudents());
            }
            else
            {
                MessageBoxResult messageBox = MessageBox.Show("No");




                ////////////////////after open DBConnectionView
                DataBaseConnectionViewModel dataBaseConnectionVM = new DataBaseConnectionViewModel();
                DatabaseConnectionView databaseConnectionView = new DatabaseConnectionView(dataBaseConnectionVM);
                
                databaseConnectionView.ShowDialog();
                //DatabaseConnection databaseConnection = new DatabaseConnection()
                //{
                //    DataBaseName = "dbname",
                //    DataSource = "dsource",
                //    Password = "pswrd",
                //    UserId = "Userid"
                //};
                //Config config = new Config(dbconnection);
                //config.SeriailizeToJson();
            }
        }
    }
}

