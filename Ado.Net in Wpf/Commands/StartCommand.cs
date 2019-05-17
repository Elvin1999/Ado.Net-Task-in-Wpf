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
                Config config = new Config();
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
                    DataBaseConnectionViewModel dataBaseConnectionVM = new DataBaseConnectionViewModel();
                    DatabaseConnectionView databaseConnectionView = new DatabaseConnectionView(dataBaseConnectionVM);
                    databaseConnectionView.ShowDialog();
                    //DatabaseConnection databaseConnection = new DatabaseConnection()
                    //{//example
                    //    DataBaseName = "StudentDb",
                    //    DataSource = @"DOCUMENTS-ПК\MYSQLSEjhnknnjRVERMSSQL",
                    //    IntergratedSecurity = true,
                    //    UserId = "",
                    //    Password = ""
                    //};

                    //Config config1 = new Config(databaseConnection);

                    //config1.SeriailizeToJson();
                }

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
                //    DataBaseName = "StudentDb",
                //    DataSource = @"DOCUMENTS-ПК\MYSQLzzzSERVERMSSQL",
                //    IntergratedSecurity = true,
                //    UserId = "",
                //    Password = ""
                //};
                //Config config = new Config(databaseConnection);
                //config.SeriailizeToJson();

            }
        }
    }
}

