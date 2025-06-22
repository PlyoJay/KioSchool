using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KioSchool.Controls;
using KioSchool.Models;
using KioSchool.View.Popups.Cafe;

namespace KioSchool.ViewModel
{
    public class MenuSelectorViewModel : INotifyPropertyChanged
    {
        private readonly BasketViewModel _basketViewModel;

        public ObservableCollection<Category> CategoryItems { get; set; }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(); // "SelectedCategory"
                }
            }
        }

        public ICommand ChangeCateogryCommand { get; }
        public ICommand OpenOptionDialogCommand { get; }


        public MenuSelectorViewModel(BasketViewModel basketVM)
        {
            _basketViewModel = basketVM;

            ChangeCateogryCommand = new RelayCommand(ChangeCategory);
            OpenOptionDialogCommand = new RelayCommand<Drink>(OpenOptionDialog);

            CategoryItems = new ObservableCollection<Category>()
            {
                new Category("커피", "Coffee", SetCoffeeList(), DrinkType.Coffee),
                new Category("차", "Tea", new ObservableCollection<Drink>(), DrinkType.Tea),
                new Category("에이드", "Ade", new ObservableCollection<Drink>(), DrinkType.Ade),
                new Category("주스", "Juice", new ObservableCollection<Drink>(), DrinkType.Juice),
            };

            SelectedCategory = CategoryItems.FirstOrDefault();
            SelectedCategory.IsSelected = true;
            Debug.WriteLine($"DrinkList Count: {SelectedCategory.DrinkList.Count}");
        }

        private void ChangeCategory(object obj)
        {
            if (obj is Category clickedCategory)
            {
                foreach (var category in CategoryItems)
                    category.IsSelected = false;

                clickedCategory.IsSelected = true;
                SelectedCategory = clickedCategory;
            }
        }

        private void OpenOptionDialog(Drink drink)
        {
            var dialogVM = new OptionsDialogViewModel(drink);
            var dialog = new OptionsPopup { DataContext = dialogVM };

            if (dialog.ShowDialog() == true)
            {
                var basketItem = dialogVM.ToBasketItem();
                _basketViewModel.AddDrink(basketItem);
            }
        }

        private ObservableCollection<Drink> SetCoffeeList()
        {
            ObservableCollection<Drink> coffeeList = new ObservableCollection<Drink>()
            {
                new(1, "아메리카노", 1600, DrinkType.Coffee, 
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(1, "카페라떼", 1900, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(1, "바닐라라떼", 2100, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(1, "카푸치노", 2100, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(1, "카페모카", 2200, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(1, "콜드브루", 1800, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    ""),
                new(1, "콜드브루 라떼", 2100, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    ""),
            };
            return coffeeList;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
