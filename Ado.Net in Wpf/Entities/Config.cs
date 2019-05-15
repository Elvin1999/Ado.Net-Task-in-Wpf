using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net_in_Wpf.Entities
{
    class Config
    {
        public DatabaseConnection DatabaseConnection { get; set; }
        public DatabaseConnection NewDatabaseConnection { get; set; }
        public Config(DatabaseConnection databaseConnection)
        {
            this.DatabaseConnection = databaseConnection;
        }
        public void SeriailizeToJson()
        {
            using(StreamWriter sw=new StreamWriter("config.json"))
            {
                var item = JsonConvert.SerializeObject(DatabaseConnection);
                sw.WriteLine(item);
            }
            //using (var streamWriter = new StreamWriter("exception.txt"))
            //{
            //    streamWriter.WriteLine(e.Message);

            //}
        }
        public void DeserializeFromJson()
        {
            
        }
        public DatabaseConnection GetConnectionElement()
        {
            return NewDatabaseConnection;
        }
    }
}
