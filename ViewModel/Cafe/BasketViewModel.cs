using KioSchool.Classes;
using KioSchool.Controls;
using KioSchool.Models;
using KioSchool.View.Pages.CafePages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace KioSchool.ViewModel
{
    public class BasketViewModel : INotifyPropertyChanged
    {
        public NavigationService NavigationService { get; set; }
        public TrainingManager _trainingManager { get; }

        private readonly CafeHomeVIewModel _homeVM;
        private readonly MenuSelectionPageViewModel _menuSelectionPageVM;

        public Basket Basket { get; } = new();

        public ObservableCollection<BasketItem> Items => Basket.Items;

        public int TotalPrice => Basket.TotalPrice;
        public int TotalCount => Basket.TotalCount;

        public ICommand MinusCommand { get; }
        public ICommand PlusCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand RemoveAllCommand { get; }
        public ICommand ToOrderPageCommand { get; }
        public ICommand ToHomeCommand { get; }

        public BasketViewModel(CafeHomeVIewModel homeVM, MenuSelectionPageViewModel menuSelectionPageVM, TrainingManager trainingManager)
        {
            _trainingManager = trainingManager;
            _homeVM = homeVM;
            _menuSelectionPageVM = menuSelectionPageVM;

            MinusCommand = new RelayCommand(obj =>
            {
                if (obj is BasketItem item)
                {
                    item.Count = Math.Max(1, item.Count - 1);
                    DecreaseDrink(item, item.Count);
                }
            });

            PlusCommand = new RelayCommand(obj =>
            {
                if (obj is BasketItem item)
                {
                    if (_trainingManager.GetIsTrainingMode())
                    {
                        string actionKey = $"AddCount:{item.Drink.Name}";
                        if (!_trainingManager.CheckAction(actionKey))
                            return;
                    }

                    item.Count = Math.Min(99, item.Count + 1);
                    AddDrink(item, item.Count);
                }
            });

            RemoveCommand = new RelayCommand(obj =>
            {
                if (obj is BasketItem item)
                {
                    if (_trainingManager.GetIsTrainingMode())
                    {
                        string actionKey = $"Remove:{item.Drink.Name}";
                        if (!_trainingManager.CheckAction(actionKey))
                            return;
                    }

                    Basket.Items.Remove(item);
                    OnPropertyChanged(nameof(Items));
                    OnPropertyChanged(nameof(TotalPrice));
                    OnPropertyChanged(nameof(TotalCount));
                }
            });

            RemoveAllCommand = new RelayCommand(obj =>
            {
                Items.Clear();
                OnPropertyChanged(nameof(Items));
                OnPropertyChanged(nameof(TotalCount));
                OnPropertyChanged(nameof(TotalPrice));
            });

            ToOrderPageCommand = new RelayCommand(obj =>
            {
                
            });

            ToHomeCommand = new RelayCommand(obj =>
            {
                if (NavigationService != null)
                    NavigationService.Navigate(new CafeHomePage(_trainingManager, _homeVM, _menuSelectionPageVM));
            });
        }

        public void AddDrink(BasketItem item, int count = 1)
        {
            Basket.AddDrink(item, count);
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(TotalCount));
            OnPropertyChanged(nameof(TotalPrice));
        }

        public void DecreaseDrink(BasketItem item, int count = 1)
        {
            Basket.DecreaseDrink(item, count);
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(TotalCount));
            OnPropertyChanged(nameof(TotalPrice));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
