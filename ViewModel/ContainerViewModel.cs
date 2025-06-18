using KioSchool.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KioSchool.ViewModel
{
    public class ContainerViewModel : INotifyPropertyChanged
    {
        private object? _currentViewModel;
        public object? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand ToHomeCommand { get; }
        public ICommand ToCafeKioskCommand { get; }
        public ICommand ToHospitalCommand { get; }


        public ContainerViewModel()
        {
            ToHomeCommand = new RelayCommand(_ => CurrentViewModel = new ContainerViewModel());
            ToCafeKioskCommand = new RelayCommand(_ => CurrentViewModel = new CafeKioskViewModel());
            ToHospitalCommand = new RelayCommand(_ => CurrentViewModel = new HospitalKioskViewModel());
        }

        private void NavigateTo()
        {
            throw new NotImplementedException();
        }

        private bool _isDrawerOpen;
        public bool IsDrawerOpen
        {
            get => _isDrawerOpen;
            set
            {
                if (_isDrawerOpen != value)
                {
                    _isDrawerOpen = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
