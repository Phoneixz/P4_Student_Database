using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using StudentDatabase.Models;
using StudentDatabase.Services;
using StudentDatabase.Views;

namespace StudentDatabase.ViewModels
{
    public class StudentViewModel : BaseViewModel
    {

        public GenericCRUDService<Student> genericCRUDService = new GenericCRUDService<Student>(new StudentDatabaseDbContextFactory());

        private ObservableCollection<Student> _students;
        
        public ObservableCollection<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        private Student _student;
        public Student Student
        {
            get => _student;
            set
            {
                _student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        private string _studentName;
        public string StudentName 
        {
            get => _studentName;
            set 
            { 
                _studentName = value; 
                OnPropertyChanged(nameof(StudentName));
            } 
        }
        private string _studentSurname;
        public string StudentSurname
        {
            get => _studentSurname;
            set
            {
                _studentSurname = value;
                OnPropertyChanged(nameof(StudentSurname));
            }
        }
        private string _studentEmail;
        public string StudentEmail

        {
            get => _studentEmail;
            set
            {
                _studentEmail = value;
                OnPropertyChanged(nameof(StudentEmail));
            }
        }
        private string _studentPhone;
        public string StudentPhone
        {
            get => _studentPhone;
            set
            {
                _studentPhone = value;
                OnPropertyChanged(nameof(StudentPhone));
            }
        }
        private int _studentYear;
        public int StudentYear
        {
            get => _studentYear;
            set
            {
                _studentYear = value;
                OnPropertyChanged(nameof(StudentYear));
            }
        }
        private string _studentStatus;

        public string StudentStatus
        {
            get => _studentStatus;
            set
            {
                _studentStatus = value;
                OnPropertyChanged(nameof(StudentStatus));
            }
        }
        
        public StudentViewModel()
        {
            _student = new();
            deleteStudentCommand = new RelayCommand<Student>((parameter) => deleteStudent(parameter));
            addStudentCommand = new RelayCommand(AddStudent);
            editWindowCommand = new RelayCommand<Student>((parameter) => editWindow(parameter));
            addWindowCommand = new RelayCommand(addWindow);
            editStudentCommand = new RelayCommand<Student>((parameter) => editStudent(parameter));
            
            
            
            
            Students = new();
            IEnumerable<Student> res = Task.Run(() => ShowAllStudentsAsync()).Result;
            foreach(var student in res)
            {
                Students.Add(student);
            }
          
        }
        public StudentViewModel(Student student) : this()
        {
            _student = new Student
            {
                Id = student.Id,
                StudentName = student.StudentName,
                StudentSurname = student.StudentSurname,
                StudentEmail = student.StudentEmail,
                StudentPhone = student.StudentPhone,
                StudentYear = student.StudentYear,
                StudentStatus = student.StudentStatus
            };
            _studentName = student.StudentName;
            _studentSurname = student.StudentSurname;
            _studentEmail = student.StudentEmail;
            _studentPhone = student.StudentPhone;
            _studentYear = student.StudentYear;
            _studentStatus = student.StudentStatus;
        }
        public ICommand addStudentCommand { get; }

        public async void AddStudent()
        {
            _student.StudentName = StudentName;
            _student.StudentSurname = StudentSurname;
            _student.StudentEmail = StudentEmail;
            _student.StudentPhone = StudentPhone;
            _student.StudentYear = StudentYear;
            _student.StudentStatus = StudentStatus;
            await genericCRUDService.Create(_student);
        }
        public ICommand addWindowCommand { get; }
        public void addWindow()
        {
            var window = new Window
            {
                Title = "Dodaj studenta",
                Content = new AddStudentView()
            };
            window.Show();
        }
        public ICommand ShowAllStudentsCommand { get; }
        
        public async Task<IEnumerable<Student>> ShowAllStudentsAsync()
        {
            return await genericCRUDService.GetAll();
        }

        public ICommand editWindowCommand { get; }

        public void editWindow(Student parameter)
        {
            var window = new Window
            {
                Title = "Edytuj studenta",
                Content = new EditStudentView()
            };
            window.DataContext = new StudentViewModel(parameter);
            window.Show();
        }

        public ICommand editStudentCommand { get; set; }

        public void editStudent(Student parameter)
        {
            parameter.StudentName = StudentName;
            parameter.StudentSurname = StudentSurname;
            parameter.StudentEmail = StudentEmail;
            parameter.StudentPhone = StudentPhone;
            parameter.StudentYear = StudentYear;
            parameter.StudentStatus = StudentStatus;
            _ = genericCRUDService.Update(parameter.Id, parameter);
        }
        public ICommand deleteStudentCommand { get; set; }
        
        public void deleteStudent(Student student)
        {
            _ = genericCRUDService.Delete(student.Id);
        }
    }
}
