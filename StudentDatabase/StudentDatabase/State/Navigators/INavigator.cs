using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentDatabase.ViewModels;
using StudentDatabase.Views;

namespace StudentDatabase.State.Navigators
{
    public enum ViewType
    {
        Student,
        Lecturer,
        Grade,
        Course,
        Department
    }
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModel { get; }
    }
}
