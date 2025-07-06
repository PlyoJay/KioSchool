using KioSchool.Controls;
using KioSchool.Models;
using KioSchool.View.Popups.Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KioSchool.ViewModel.Cafe
{
    public class DrinkSelectionViewModel
    {
        private readonly BasketViewModel _basketViewModel;

        public Category SelectedCategory { get; set; }

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
    }
}
