using Ado.Net_in_Wpf.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ado.Net_in_Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            DatabaseConnection databaseConnection = new DatabaseConnection()
            {
                DataBaseName = "",
                DataSource = @"",
                IntergratedSecurity = true,
                UserId = "",
                Password = ""
            };
            DB = new DataAccessLayer(databaseConnection);

        }
        public static bool IsConnectedSuccessfully { get; set; }
        public static DataAccessLayer DB;
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            string content = e.Message;
            using (var streamWriter = new StreamWriter("exception.txt", true))
            {
                streamWriter.WriteLine(e.Message);

            }
        }
    }
}
