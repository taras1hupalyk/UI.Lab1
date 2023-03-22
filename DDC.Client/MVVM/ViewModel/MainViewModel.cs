using DDC.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDC.Client.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DebtViewCommand { get; set; }
        public RelayCommand DepositViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public DebtViewModel DebtVM { get; set; }
        public DepositViewModel DepositVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new();
            DebtVM = new();
            DepositVM = new();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            DebtViewCommand = new RelayCommand(o =>
            {
                CurrentView = DebtVM;
            });

            DepositViewCommand = new RelayCommand(o =>
            {
                CurrentView = DepositVM;
            });


        }

        
    }
}
