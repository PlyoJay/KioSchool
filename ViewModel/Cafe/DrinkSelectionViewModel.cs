using KioSchool.Controls;
using KioSchool.Models;
using KioSchool.View.Popups.Cafe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly BasketViewModel _basketViewModel;

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                    OnPropertyChanged(nameof(DrinkList)); // DrinkList도 새로 알림
                }
            }
        }

        public ObservableCollection<Drink> DrinkList => SelectedCategory?.DrinkList;


        public ICommand OpenOptionDialogCommand { get; }


        public DrinkSelectionViewModel(BasketViewModel basketVM)
        {
            _basketViewModel = basketVM;

            OpenOptionDialogCommand = new RelayCommand<Drink>(OpenOptionDialog);

        }

        private void OpenOptionDialog(Drink drink)
        {
            var dialogVM = new OptionsDialogViewModel(drink);
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
