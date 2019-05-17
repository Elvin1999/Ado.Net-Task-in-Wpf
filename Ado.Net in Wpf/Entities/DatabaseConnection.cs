using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net_in_Wpf.Entities
{
    public class DatabaseConnection
    {
        public string DataSource { get; set; } = "localhost";
        public string DataBaseName { get; set; } = "localDb";
        private string userId;
        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {

                if (value == null || value==String.Empty)
                {
                    userId = "user";
                }
                else
                {
                    userId = value;
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
                if (value == null || value==String.Empty)
                {
                    password = "password";
                }
                else
                {
                    password = value;
                }
            }
        }
        public bool IntergratedSecurity { get; set; }
    }
}

