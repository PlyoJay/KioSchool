using KioSchool.Controls;
using KioSchool.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace KioSchool.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MenuItemModel> MenuItems { get; }

        private object? _currentViewModel;
        public object? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();

                IsMenuToggleVisible = !(value is HomeViewModel);
            }
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

        private bool _isMenuToggleVisible;
        public bool IsMenuToggleVisible
        {
            get => _isMenuToggleVisible;
            private set
            {
                if (_isMenuToggleVisible != value)
                {
                    _isMenuToggleVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToHomeCommand { get; }
        public ICommand ToCafeKioskCommand { get; }
        public ICommand ToHospitalCommand { get; }

        public MainViewModel()
        {
            ToHomeCommand = new RelayCommand(_ => CurrentViewModel = new HomeViewModel());
            ToCafeKioskCommand = new RelayCommand(_ => CurrentViewModel = new CafeKioskViewModel());
            ToHospitalCommand = new RelayCommand(_ => CurrentViewModel = new HospitalKioskViewModel());

            // 시작화면
            CurrentViewModel = new HomeViewModel();
            IsMenuToggleVisible = false;

            MenuItems = new ObservableCollection<MenuItemModel>
            {
                new MenuItemModel { IconKind = "Home", Label = "홈으로 돌아가기", Command = ToHomeCommand },
                new MenuItemModel { IconKind = "LocalCafe", Label = "카페 주문하기", Command = ToCafeKioskCommand },
                new MenuItemModel { IconKind = "HospitalBuilding", Label = "병원 접수하기", Command = ToHospitalCommand }
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
