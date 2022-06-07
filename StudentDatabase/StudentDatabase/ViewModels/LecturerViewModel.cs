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
    public class LecturerViewModel : BaseViewModel
    {
        public GenericCRUDService<Lecturer> genericCRUDService = new GenericCRUDService<Lecturer>(new StudentDatabaseDbContextFactory());

        private ObservableCollection<Lecturer> _lecturers;

        public ObservableCollection<Lecturer> Lecturers
        {
            get => _lecturers;
            set
            {
                _lecturers = value;
                OnPropertyChanged(nameof(Lecturers));
            }
        }

        private Lecturer _lecturer;
        public Lecturer Lecturer
        {
            get => _lecturer;
            set
            {
                _lecturer = value;
                OnPropertyChanged(nameof(Lecturer));
            }
        }

        private string _lecturerName;
        public string LecturerName
        {
            get => _lecturerName;
            set
            {
                _lecturerName = value;
                OnPropertyChanged(nameof(LecturerName));
            }
        }
        private string _lecturerSurname;
        public string LecturerSurname
        {
            get => _lecturerSurname;
            set
            {
                _lecturerSurname = value;
                OnPropertyChanged(nameof(LecturerSurname));
            }
        }
        private string _lecturerEmail;
        public string LecturerEmail

        {
            get => _lecturerEmail;
            set
            {
                _lecturerEmail = value;
                OnPropertyChanged(nameof(LecturerEmail));
            }
        }
        private string _lecturerPhone;
        public string LecturerPhone
        {
            get => _lecturerPhone;
            set
            {
                _lecturerPhone = value;
                OnPropertyChanged(nameof(LecturerPhone));
            }
        }

        public LecturerViewModel()
        {
            _lecturer = new();
            deleteLecturerCommand = new RelayCommand<Lecturer>((parameter) => deleteLecturer(parameter));
            addLecturerCommand = new RelayCommand(AddLecturer);
            editWindowCommand = new RelayCommand<Lecturer>((parameter) => editWindow(parameter));
            addWindowCommand = new RelayCommand(addWindow);
            editLecturerCommand = new RelayCommand<Lecturer>((parameter) => editLecturer(parameter));




            Lecturers = new();
            IEnumerable<Lecturer> res = Task.Run(() => ShowAllLecturersAsync()).Result;
            foreach (var lecturer in res)
            {
                Lecturers.Add(lecturer);
            }

        }
        public LecturerViewModel(Lecturer lecturer) : this()
        {
            _lecturer = new Lecturer
            {
                Id = Lecturer.Id,
                LecturerName = lecturer.LecturerName,
                LecturerSurname = lecturer.LecturerSurname,
                LecturerEmail = lecturer.LecturerEmail,
                LecturerPhone = lecturer.LecturerPhone
            };
            _lecturerName = lecturer.LecturerName;
            _lecturerSurname = lecturer.LecturerSurname;
            _lecturerEmail = lecturer.LecturerEmail;
            _lecturerPhone = lecturer.LecturerPhone;
           
        }
        public ICommand addLecturerCommand { get; }

        public async void AddLecturer()
        {
            _lecturer.LecturerName = LecturerName;
            _lecturer.LecturerSurname = LecturerSurname;
            _lecturer.LecturerEmail = LecturerEmail;
            _lecturer.LecturerPhone = LecturerPhone;
            await genericCRUDService.Create(_lecturer);
        }
        public ICommand addWindowCommand { get; }
        public void addWindow()
        {
            var window = new Window
            {
                Title = "Dodaj wykładowcę",
                Content = new AddLecturerView()
            };
            window.Show();
        }
        public ICommand ShowAllLecturersCommand { get; }

        public async Task<IEnumerable<Lecturer>> ShowAllLecturersAsync()
        {
            return await genericCRUDService.GetAll();
        }

        public ICommand editWindowCommand { get; }

        public void editWindow(Lecturer parameter)
        {
            var window = new Window
            {
                Title = "Edytuj studenta",
                Content = new EditLecturerView()
            };
            window.DataContext = new LecturerViewModel(parameter);
            window.Show();
        }

        public ICommand editLecturerCommand { get; set; }

        public void editLecturer(Lecturer parameter)
        {
            parameter.LecturerName = LecturerName;
            parameter.LecturerSurname = LecturerSurname;
            parameter.LecturerEmail = LecturerEmail;
            parameter.LecturerPhone = LecturerPhone;
            _ = genericCRUDService.Update(parameter.Id, parameter);
        }
        public ICommand deleteLecturerCommand { get; set; }

        public void deleteLecturer(Lecturer lecturer)
        {
            _ = genericCRUDService.Delete(lecturer.Id);
        }
    }
}

