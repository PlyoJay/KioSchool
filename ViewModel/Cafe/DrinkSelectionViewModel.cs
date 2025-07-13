using KioSchool.Classes;
using KioSchool.Controls;
using KioSchool.Models;
using KioSchool.View.Popups.Cafe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KioSchool.ViewModel.Cafe
{
    public class DrinkSelectionViewModel : INotifyPropertyChanged
    {
        public TrainingManager _trainingManager;
        private readonly BasketViewModel _basketViewModel;

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    // 이전 DrinkList의 이벤트 해제
                    if (_selectedCategory?.DrinkList != null)
                        _selectedCategory.DrinkList.CollectionChanged -= OnDrinkListChanged;

                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                    OnPropertyChanged(nameof(DrinkList));

                    // 새로운 DrinkList의 이벤트 연결
                    if (_selectedCategory?.DrinkList != null)
                        _selectedCategory.DrinkList.CollectionChanged += OnDrinkListChanged;

                    // DrinkList가 바뀐 것이므로 즉시 UI 갱신용 이벤트도 호출
                    OnDrinkListChanged(this, null);
                }

            }
        }

        public event Action<object?, int>? DrinkListUpdated;

        public ObservableCollection<Drink> DrinkList => SelectedCategory?.DrinkList;


        public ICommand OpenOptionDialogCommand { get; }


        public DrinkSelectionViewModel(BasketViewModel basketVM, TrainingManager trainingManager)
        {
            _basketViewModel = basketVM;
            _trainingManager = trainingManager;
            OpenOptionDialogCommand = new RelayCommand<Drink>(OpenOptionDialog);
        }

        private void OnDrinkListChanged(object? sender, NotifyCollectionChangedEventArgs? e)
        {
            int count = SelectedCategory?.DrinkList?.Count ?? 0;
            DrinkListUpdated?.Invoke(this, count);
        }

        private void OpenOptionDialog(Drink drink)
        {
            if (_trainingManager != null)
            {
                string actionKey = $"SelectDrink:{drink.Name}";
                if (!_trainingManager.CheckAction(actionKey))
                    return; // 틀리면 중단
            }

            var dialogVM = new OptionsDialogViewModel(drink, _trainingManager);
            var dialog = new OptionsPopup { DataContext = dialogVM };

            if (dialog.ShowDialog() == true)
            {
                var basketItem = dialogVM.ToBasketItem();
                _basketViewModel.AddDrink(basketItem, basketItem.Count);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
