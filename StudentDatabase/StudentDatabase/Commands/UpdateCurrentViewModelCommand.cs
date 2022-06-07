using StudentDatabase.State.Navigators;
using StudentDatabase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentDatabase.Models;
using static StudentDatabase.State.Navigators.INavigator;

namespace StudentDatabase.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch(viewType)
                {
                    case ViewType.Student:
                        _navigator.CurrentViewModel = new StudentViewModel();
                        break;
                    case ViewType.Course:
                        _navigator.CurrentViewModel = new CourseViewModel();
                        break;
                    case ViewType.Grade:
                        _navigator.CurrentViewModel = new GradeViewModel();
                        break;
                    case ViewType.Lecturer:
                        _navigator.CurrentViewModel = new LecturerViewModel();
                        break;
                    case ViewType.Department:
                        _navigator.CurrentViewModel = new DepartmentViewModel();
                        break;
                }
            }
        }
    }
}
