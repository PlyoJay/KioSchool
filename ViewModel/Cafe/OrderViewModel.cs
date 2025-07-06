using KioSchool.ViewModel.Cafe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KioSchool.ViewModel
{
    class OrderViewModel : INotifyPropertyChanged
    {
        public CategoryViewModel CategoryVM { get; }
        public DrinkSelectionViewModel DrinkSelectionVM { get; }
        public BasketViewModel BasketVM { get; }

        public OrderViewModel()
        {
            BasketVM = new BasketViewModel();
            DrinkSelectionVM = new DrinkSelectionViewModel(BasketVM);
            CategoryVM = new CategoryViewModel(DrinkSelectionVM);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
