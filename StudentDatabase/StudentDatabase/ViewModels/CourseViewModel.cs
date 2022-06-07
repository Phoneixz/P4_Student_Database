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
    public class CourseViewModel : BaseViewModel
    {
        public GenericCRUDService<Course> genericCRUDService = new GenericCRUDService<Course>(new StudentDatabaseDbContextFactory());

        private ObservableCollection<Course> _courses;

        public ObservableCollection<Course> Courses
        {
            get => _courses;
            set
            {
                _courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        private Course _course;
        public Course Course
        {
            get => _course;
            set
            {
                _course = value;
                OnPropertyChanged(nameof(Course));
            }
        }

        private string _CourseName;
        public string CourseName
        {
            get => _CourseName;
            set
            {
                _CourseName = value;
                OnPropertyChanged(nameof(CourseName));
            }
        }
        private string _CourseDesc;
        public string CourseDesc
        {
            get => _CourseDesc;
            set
            {
                _CourseDesc = value;
                OnPropertyChanged(nameof(CourseDesc));
            }
        }
        private string _CourseType;
        public string CourseType

        {
            get => _CourseType;
            set
            {
                _CourseType = value;
                OnPropertyChanged(nameof(CourseType));
            }
        }
        
        private int _CourseLength;
        public int CourseLength
        {
            get => _CourseLength;
            set
            {
                _CourseLength = value;
                OnPropertyChanged(nameof(CourseLength));
            }
        }
        private string _CourseStatus;

        public string CourseStatus
        {
            get => _CourseStatus;
            set
            {
                _CourseStatus = value;
                OnPropertyChanged(nameof(CourseStatus));
            }
        }

        public CourseViewModel()
        {
            _course = new();
            DeleteCourseCommand = new RelayCommand<Course>((parameter) => DeleteCourse(parameter));
            AddCourseCommand = new RelayCommand(AddCourse);
            EditCourseWindowCommand = new RelayCommand<Course>((parameter) => EditWindow(parameter));
            AddCourseWindowCommand = new RelayCommand(AddWindow);
            EditCourseCommand = new RelayCommand<Course>((parameter) => EditCourse(parameter));




            Courses = new();
            IEnumerable<Course> res = Task.Run(() => ShowAllCoursesAsync()).Result;
            foreach (var course in res)
            {
                Courses.Add(course);
            }

        }
        public CourseViewModel(Course course) : this()
        {
            _course = new Course
            {
                Id = course.Id,
                CourseName = course.CourseName,
                CourseDesc = course.CourseDesc,
                CourseType = course.CourseType,
                CourseLength = course.CourseLength,
                CourseStatus = course.CourseStatus
            };
            _CourseName = course.CourseName;
            _CourseDesc = course.CourseDesc;
            _CourseType = course.CourseType;
            _CourseLength = course.CourseLength;
            _CourseStatus = course.CourseStatus;
        }
        public ICommand AddCourseCommand { get; }

        public async void AddCourse()
        {
            _course.CourseName = CourseName;
            _course.CourseDesc = CourseDesc;
            _course.CourseType = CourseType;
            _course.CourseLength = CourseLength;
            _course.CourseStatus = CourseStatus;
            await genericCRUDService.Create(_course);
        }
        public ICommand AddCourseWindowCommand { get; }
        public void AddWindow()
        {
            var window = new Window
            {
                Title = "Dodaj przedmiot",
                Content = new AddCourseView()
            };
            window.Show();
        }
        public ICommand ShowAllCoursesCommand { get; }

        public async Task<IEnumerable<Course>> ShowAllCoursesAsync()
        {
            return await genericCRUDService.GetAll();
        }

        public ICommand EditCourseWindowCommand { get; }

        public void EditWindow(Course parameter)
        {
            var window = new Window
            {
                Title = "Edytuj przedmiot",
                Content = new EditCourseView()
            };
            window.DataContext = new CourseViewModel(parameter);
            window.Show();
        }

        public ICommand EditCourseCommand { get; set; }

        public void EditCourse(Course parameter)
        {
            parameter.CourseName = CourseName;
            parameter.CourseDesc = CourseDesc;
            parameter.CourseType = CourseType;
            parameter.CourseLength = CourseLength;
            parameter.CourseStatus = CourseStatus;
            _ = genericCRUDService.Update(parameter.Id, parameter);
        }
        public ICommand DeleteCourseCommand { get; set; }

        public void DeleteCourse(Course course)
        {
            _ = genericCRUDService.Delete(course.Id);
        }
    }
}