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
    public class GradeViewModel : BaseViewModel
    {
        public GenericCRUDService<Grade> genericCRUDService = new GenericCRUDService<Grade>(new StudentDatabaseDbContextFactory());

        private ObservableCollection<Grade> _grades;

        public ObservableCollection<Grade> Grades
        {
            get => _grades;
            set
            {
                _grades = value;
                OnPropertyChanged(nameof(Grades));
            }
        }

        private Grade _grade;
        public Grade Grade
        {
            get => _grade;
            set
            {
                _grade = value;
                OnPropertyChanged(nameof(Grade));
            }
        }

        private int _GradeValue;
        public int GradeValue
        {
            get => _GradeValue;
            set
            {
                _GradeValue = value;
                OnPropertyChanged(nameof(GradeValue));
            }
        }
        private DateTime _GradeDate;
        public DateTime GradeDate
        {
            get => _GradeDate;
            set
            {
                _GradeDate = value;
                OnPropertyChanged(nameof(GradeDate));
            }
        }
        private string _GradeName;
        public string GradeName
        {
            get => _GradeName;
            set
            {
                _GradeName = value;
                OnPropertyChanged(nameof(GradeName));
            }
        }
        private string _GradeType;
        public string GradeType

        {
            get => _GradeType;
            set
            {
                _GradeType = value;
                OnPropertyChanged(nameof(GradeType));
            }
        }

       

        public GradeViewModel()
        {
            _grade = new();
            DeleteGradeCommand = new RelayCommand<Grade>((parameter) => DeleteGrade(parameter));
            AddGradeCommand = new RelayCommand(AddGrade);
            EditGradeWindowCommand = new RelayCommand<Grade>((parameter) => EditWindow(parameter));
            AddGradeWindowCommand = new RelayCommand(AddWindow);
            EditGradeCommand = new RelayCommand<Grade>((parameter) => EditGrade(parameter));




            Grades = new();
            IEnumerable<Grade> res = Task.Run(() => ShowAllGradesAsync()).Result;
            foreach (var grade in res)
            {
                Grades.Add(grade);
            }

        }
        public GradeViewModel(Grade grade) : this()
        {
            _grade = new Grade
            {
                Id = Grade.Id,
                GradeValue = grade.GradeValue,
                GradeDate = grade.GradeDate,
                GradeName = grade.GradeName,
                GradeType = grade.GradeType
            };
            _GradeValue = grade.GradeValue;
            _GradeDate = grade.GradeDate;
            _GradeName = grade.GradeName;
            _GradeType = grade.GradeType;
        }
        public ICommand AddGradeCommand { get; }

        public async void AddGrade()
        {
            _grade.GradeValue = GradeValue;
            _grade.GradeDate = GradeDate;
            _grade.GradeName = GradeName;
            _grade.GradeType = GradeType;
            await genericCRUDService.Create(_grade);
        }
        public ICommand AddGradeWindowCommand { get; }
        public void AddWindow()
        {
            var window = new Window
            {
                Title = "Dodaj ocenę",
                Content = new AddGradeView()
            };
            window.Show();
        }
        public ICommand ShowAllGradesCommand { get; }

        public async Task<IEnumerable<Grade>> ShowAllGradesAsync()
        {
            return await genericCRUDService.GetAll();
        }

        public ICommand EditGradeWindowCommand { get; }

        public void EditWindow(Grade parameter)
        {
            var window = new Window
            {
                Title = "Edytuj ocenę",
                Content = new EditGradeView()
            };
            window.DataContext = new GradeViewModel(parameter);
            window.Show();
        }

        public ICommand EditGradeCommand { get; set; }

        public void EditGrade(Grade parameter)
        {
            parameter.GradeValue = GradeValue;
            parameter.GradeDate = GradeDate;
            parameter.GradeName = GradeName;
            parameter.GradeType = GradeType;
            _ = genericCRUDService.Update(parameter.Id, parameter);
        }
        public ICommand DeleteGradeCommand { get; set; }

        public void DeleteGrade(Grade Grade)
        {
            _ = genericCRUDService.Delete(Grade.Id);
        }
    }

}

