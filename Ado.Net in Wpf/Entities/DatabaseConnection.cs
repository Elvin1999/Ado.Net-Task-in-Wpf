using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net_in_Wpf.Entities
{
   public class DatabaseConnection
    {
        public string DataSource { get; set; }
        public string DataBaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool IntergratedSecurity { get; set; }
    }
}

