using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentDatabase.Commands;
using StudentDatabase.ViewModels;
using StudentDatabase.Views;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace StudentDatabase.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel 
        { 
            get
            {
                return _currentViewModel;
            }
         
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public ICommand UpdateCurrentViewModel => new UpdateCurrentViewModelCommand(this);

    }
}
