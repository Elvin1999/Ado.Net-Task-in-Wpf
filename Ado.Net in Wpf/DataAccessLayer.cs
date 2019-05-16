using Ado.Net_in_Wpf.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ado.Net_in_Wpf
{
   public class DataAccessLayer
    {
        public string ConnectionString { get; set; }
        public DatabaseConnection  DatabaseConnection { get; set; }
        
        public DataAccessLayer(DatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DatabaseConnection.DataSource;
            builder.InitialCatalog = DatabaseConnection.DataBaseName;
            builder.UserID = DatabaseConnection.UserId;
            builder.IntegratedSecurity = true;
            builder.Password = DatabaseConnection.Password;
            ConnectionString = builder.ToString();
        }
        public List<Student> GetStudents()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string cmdText = @"select *from Students";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();
                    while (reader.Read())
                    {
                        Student student = new Student();

                        //product.Id = reader.GetInt32(0);
                        //product.Name = reader.GetString(1);
                        //product.Barcode = reader.GetString(2);
                        //product.Price = reader.GetDecimal(3);

                        //product.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        //product.Name = reader.GetString(reader.GetOrdinal("Name"));
                        //product.Barcode = reader.GetString(reader.GetOrdinal("Barcode"));
                        //product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));


                        //product.Price = reader.IsDBNull(reader.GetOrdinal("Price")) ? null : (decimal?) reader.GetDecimal(reader.GetOrdinal("Price"));

                        //product.Id = Convert.ToInt32(reader[0]);
                        //product.Name = Convert.ToString(reader[1]);
                        //product.Barcode = Convert.ToString(reader[2]);
                        //product.Price = Convert.ToDecimal(reader[3]);

                        student.Id = Convert.ToInt32(reader[nameof(student.Id)]);
                        student.Name = Convert.ToString(reader[nameof(student.Name)]);
                        student.Surname = Convert.ToString(reader[nameof(student.Surname)]);
                        student.Age = Convert.ToInt32(reader[nameof(student.Age)]);
                        student.IsMonitor = Convert.ToBoolean(reader[nameof(student.IsMonitor)]);
                        MessageBoxResult mb = MessageBox.Show(student.Name);
                        //student.Filial.Name = Convert.ToString(reader["Filial_Name"]);
                        //student.Note = reader.IsDBNull(reader.GetOrdinal("Note")) ? null : reader.GetString(reader.GetOrdinal("Note"));

                        students.Add(student);
                    }
                    return students;

                }
            }
        }

        //public int AddProduct(Group group)
        //{
        //    using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    {
        //        conn.Open();
        //        string cmdText = $"Insert into Products output inserted.Id values(@Name, @Barcode, @Price)";
        //        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Name", group.Name);
        //            cmd.Parameters.AddWithValue("@Barcode", group.Barcode);
        //            cmd.Parameters.AddWithValue("@Price", group.Price);

        //            //cmd.ExecuteNonQuery();
        //            return (int)cmd.ExecuteScalar();
        //        }
        //    }
        //}

    }
}
