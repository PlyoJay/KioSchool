using KioSchool.ViewModel.Cafe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace KioSchool.ViewModel
{
    class OrderViewModel : INotifyPropertyChanged
    {
        public CategoryViewModel CategoryVM { get; }
        public DrinkSelectionViewModel DrinkSelectionVM { get; }
        public BasketViewModel BasketVM { get; }

        public OrderViewModel(BasketViewModel basketVM, DrinkSelectionViewModel drinkSelectionVM, CategoryViewModel categoryVM)
        {
            BasketVM = basketVM;
            DrinkSelectionVM = drinkSelectionVM;
            CategoryVM = categoryVM;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
