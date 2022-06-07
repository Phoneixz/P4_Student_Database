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
    public class DepartmentViewModel : BaseViewModel
    {
        public GenericCRUDService<Department> genericCRUDService = new GenericCRUDService<Department>(new StudentDatabaseDbContextFactory());

        private ObservableCollection<Department> _departments;

        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set
            {
                _departments = value;
                OnPropertyChanged(nameof(Departments));
            }
        }

        private Department _department;
        public Department Department
        {
            get => _department;
            set
            {
                _department = value;
                OnPropertyChanged(nameof(Department));
            }
        }

        private string _DepartmentName;
        public string DepartmentName
        {
            get => _DepartmentName;
            set
            {
                _DepartmentName = value;
                OnPropertyChanged(nameof(DepartmentName));
            }
        }
        private string _DepartmentSupervisor;
        public string DepartmentSupervisor
        {
            get => _DepartmentSupervisor;
            set
            {
                _DepartmentSupervisor = value;
                OnPropertyChanged(nameof(DepartmentSupervisor));
            }
        }

        public DepartmentViewModel()
        {
            _department = new();
            DeleteDepartmentCommand = new RelayCommand<Department>((parameter) => DeleteDepartment(parameter));
            AddDepartmentCommand = new RelayCommand(AddDepartment);
            EditDepartmentWindowCommand = new RelayCommand<Department>((parameter) => EditWindow(parameter));
            AddDepartmentWindowCommand = new RelayCommand(AddWindow);
            EditDepartmentCommand = new RelayCommand<Department>((parameter) => EditDepartment(parameter));




            Departments = new();
            IEnumerable<Department> res = Task.Run(() => ShowAllDepartmentsAsync()).Result;
            foreach (var Department in res)
            {
                Departments.Add(Department);
            }

        }
        public DepartmentViewModel(Department department) : this()
        {
            _department = new Department
            {
                Id = Department.Id,
                DepartmentName = department.DepartmentName,
                DepartmentSupervisor = department.DepartmentSupervisor,
            };
            _DepartmentName = department.DepartmentName;
            _DepartmentSupervisor = department.DepartmentSupervisor;
            
        }
        public ICommand AddDepartmentCommand { get; }

        public async void AddDepartment()
        {
            _department.DepartmentName = DepartmentName;
            _department.DepartmentSupervisor = DepartmentSupervisor;
            await genericCRUDService.Create(_department);
        }
        public ICommand AddDepartmentWindowCommand { get; }
        public void AddWindow()
        {
            var window = new Window
            {
                Title = "Dodaj wydział",
                Content = new AddDepartmentView()
            };
            window.Show();
        }
        public ICommand ShowAllDepartmentsCommand { get; }

        public async Task<IEnumerable<Department>> ShowAllDepartmentsAsync()
        {
            return await genericCRUDService.GetAll();
        }

        public ICommand EditDepartmentWindowCommand { get; }

        public void EditWindow(Department parameter)
        {
            var window = new Window
            {
                Title = "Edytuj wydział",
                Content = new EditDepartmentView()
            };
            window.DataContext = new DepartmentViewModel(parameter);
            window.Show();
        }

        public ICommand EditDepartmentCommand { get; set; }

        public void EditDepartment(Department parameter)
        {
            parameter.DepartmentName = DepartmentName;
            parameter.DepartmentSupervisor = DepartmentSupervisor;
            _ = genericCRUDService.Update(parameter.Id, parameter);
        }
        public ICommand DeleteDepartmentCommand { get; set; }

        public void DeleteDepartment(Department Department)
        {
            _ = genericCRUDService.Delete(Department.Id);
        }
    }
}

