using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net_in_Wpf.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        private bool isMonitor;
        public bool IsMonitor
        {
            get
            {
                return IsMonitor;
            }
            set
            {
                isMonitor = value;
                if (isMonitor)
                {
                    Monitor = "Yes";
                }
                else
                {
                    Monitor = "No";
                }
            }
        }
        public string Monitor { get; set; }
        public Student Clone()
        {
            Student newStudent = new Student()
            {
                Id = this.Id,
                No = this.No,
                Name = this.Name,
                Surname = this.Surname,
                Age = this.Age,
                IsMonitor = this.IsMonitor
            };
            return newStudent;
        }
    }
}

