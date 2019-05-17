using Ado.Net_in_Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ado.Net_in_Wpf.Views
{
    /// <summary>
    /// Interaction logic for DatabaseConnectionView.xaml
    /// </summary>
    public partial class DatabaseConnectionView : Window
    {
        public DataBaseConnectionViewModel DBConnectionVM { get; set; }
        public DatabaseConnectionView(DataBaseConnectionViewModel DBConnectionVM)
        {
            InitializeComponent();
            this.DBConnectionVM = DBConnectionVM;
            DataContext = DBConnectionVM;
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
