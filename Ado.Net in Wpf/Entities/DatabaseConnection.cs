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
        private string userId;
        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                if (value != String.Empty || value != null)
                {
                    userId = value;
                }
                else
                {
                    userId = String.Empty;
                }
            }
        }
        private string password;
        public string Password
        {
            get
            {

                return password;
            }
            set
            {
                if (value != String.Empty || value != null)
                {
                    password = value;
                }
                else
                {
                    password = String.Empty;
                }

            }
        }
        public bool IntergratedSecurity { get; set; }
    }
}

