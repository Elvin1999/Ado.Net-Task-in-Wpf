using Ado.Net_in_Wpf.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net_in_Wpf.ViewModels
{
    public class StudentViewModel : BaseViewModel
    {
        private Student currentStudent;
        public Student CurrentStudent
        {
            get
            {
                return currentStudent;

            }
            set
            {
                currentStudent = value;
                OnPropertyCanged(new PropertyChangedEventArgs(nameof(CurrentStudent)));
               
            }
        }
        private Student selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return selectedStudent;

            }
            set
            {
                selectedStudent = value;
                if (value != null)
                {
                    CurrentStudent = SelectedStudent.Clone();
                }
                OnPropertyCanged(new PropertyChangedEventArgs(nameof(SelectedStudent)));
            }
        }
        private ObservableCollection<Student> allStudents;
        public ObservableCollection<Student> AllStudents
        {
            get
            {
                return allStudents;
            }
            set
            {

                allStudents = value;
                OnPropertyCanged(new PropertyChangedEventArgs(nameof(AllStudents)));
            }
        }
    }
}
