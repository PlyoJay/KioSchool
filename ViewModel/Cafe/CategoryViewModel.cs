using KioSchool.Controls;
using KioSchool.Models;
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
    public class CategoryViewModel : INotifyPropertyChanged
    {
        public DrinkSelectionViewModel _drinkSelectionViewModel { get; set; }

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

        public CategoryViewModel( DrinkSelectionViewModel drinkSelectionVM)
        {
            _drinkSelectionViewModel = drinkSelectionVM;

            ChangeCateogryCommand = new RelayCommand(ChangeCategory);

            CategoryItems = new ObservableCollection<Category>()
            {
                new Category("커피", "Coffee", CafeDrinkData.SetCoffeeList(), DrinkType.Coffee),
                new Category("차", "Tea", CafeDrinkData.SetTeaList(), DrinkType.Tea),
                new Category("에이드/주스", "Ade/Juice", CafeDrinkData.SetAdeNJuiceList(), DrinkType.AdeNJuisce),
                new Category("요거트", "Yogurt", CafeDrinkData.SetYogurtList(), DrinkType.Yogurt),
            };

            SelectedCategory = CategoryItems.FirstOrDefault();
            SelectedCategory.IsSelected = true;
            _drinkSelectionViewModel.SelectedCategory = SelectedCategory;
        }

        private void ChangeCategory(object obj)
        {
            if (obj is Category clickedCategory)
            {
                foreach (var category in CategoryItems)
                    category.IsSelected = false;

                clickedCategory.IsSelected = true;
                SelectedCategory = clickedCategory;
                _drinkSelectionViewModel.SelectedCategory = SelectedCategory;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
