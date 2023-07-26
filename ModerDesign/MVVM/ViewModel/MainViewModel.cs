using ModerDesign.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerDesign.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public HomeViewModel HomeVm { get; set; }

        private object _CurrentView;

        public object CurrentView
        {
            get { return _CurrentView; }
            set
            {
                _CurrentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel() 
        {
            HomeVm = new HomeViewModel();
            CurrentView = HomeVm;
        }
    }
}   
