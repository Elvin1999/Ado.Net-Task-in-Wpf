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
        public DatabaseConnection DatabaseConnection { get; set; }

        public DataAccessLayer(DatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DatabaseConnection.DataSource;
            builder.InitialCatalog = DatabaseConnection.DataBaseName;

            if (DatabaseConnection.Password != null && DatabaseConnection.UserId != null)
            {
                builder.UserID = DatabaseConnection.UserId;
                builder.Password = DatabaseConnection.Password;
                builder.IntegratedSecurity = false;
            }

            ConnectionString = builder.ToString();
        }
        int counter = 0;
        List<Student> students;
        public List<Student> GetStudents()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string cmdText = @"select *from Students";
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        students = new List<Student>();
                        while (reader.Read())
                        {
                            Student student = new Student();
                            student.No = ++counter;
                            student.Id = Convert.ToInt32(reader[nameof(student.Id)]);
                            student.Name = Convert.ToString(reader[nameof(student.Name)]);
                            student.Surname = Convert.ToString(reader[nameof(student.Surname)]);
                            student.Age = Convert.ToInt32(reader[nameof(student.Age)]);
                            //student.IsMonitor = Convert.ToBoolean(reader[nameof(student.IsMonitor)]);
                            //student.IsMonitor = reader.GetBoolean(reader.GetOrdinal("IsMonitor"));

                            var text = Convert.ToString(reader[nameof(student.IsMonitor)]);
                            student.IsMonitor = Convert.ToBoolean(text);

                            //student.Filial.Name = Convert.ToString(reader["Filial_Name"]);
                            //student.Note = reader.IsDBNull(reader.GetOrdinal("Note")) ? null : reader.GetString(reader.GetOrdinal("Note"));
                            students.Add(student);
                        }
                        return students;
                    }
                }
                catch (Exception)
                {
                   
                }

         

            }
            return null;
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






