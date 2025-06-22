using KioSchool.Controls;
using KioSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KioSchool.ViewModel
{
    public class OptionsDialogViewModel : INotifyPropertyChanged
    {
        public Drink Drink { get; }
        public DrinkSize SelectedSize { get; set; }
        public DrinkTemperature SelectedTemperature { get; set; }

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public OptionsDialogViewModel(Drink drink)
        {
            Drink = drink;
            SelectedSize = drink.Sizes.First();
            SelectedTemperature = drink.DrinkTemperatures.First();

            //OkCommand = new RelayCommand<Window>(w => Close(w, true));
            //CancelCommand = new RelayCommand<Window>(w => Close(w, false));
        }

        private void Close(Window w, bool result)
        {
            w.DialogResult = result;
            w.Close();
        }

        /* BasketItem 생성기 */
        public BasketItem ToBasketItem(int count = 1) =>
            new()
            {
                Drink = Drink,
                Size = SelectedSize,
                Temperature = SelectedTemperature,
                Count = count
            };

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
