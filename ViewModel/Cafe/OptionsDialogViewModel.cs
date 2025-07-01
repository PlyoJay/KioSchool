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

        private DrinkSize _selectedSize;
        public DrinkSize SelectedSize
        {
            get => _selectedSize;
            set
            {
                if (_selectedSize != value)
                {
                    _selectedSize = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        private DrinkTemperature _selectedTemperature;
        public DrinkTemperature SelectedTemperature
        {
            get => _selectedTemperature;
            set
            {
                if (_selectedTemperature != value)
                {
                    _selectedTemperature = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _count = 1;
        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public int TotalPrice => Count * (Drink.Price + (int)SelectedSize);

        public ICommand SelectTemperatureCommand { get; }
        public ICommand SelectSizeCommand { get; }
        public ICommand MinusCommand { get; }
        public ICommand PlusCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand ConfirmCommand { get; }

        public OptionsDialogViewModel(Drink drink)
        {
            Drink = drink;
            SelectedSize = drink.Sizes.First();
            SelectedTemperature = drink.Temperatures.First();

            SelectTemperatureCommand = new RelayCommand(temp => SelectedTemperature = (DrinkTemperature)temp);
            SelectSizeCommand = new RelayCommand(size => SelectedSize = (DrinkSize)size);
            MinusCommand = new RelayCommand(MinusCount);
            PlusCommand = new RelayCommand(PlusCount);
            CancelCommand = new RelayCommand<Window>(w => Close(w, false), w => w != null);
            ConfirmCommand = new RelayCommand<Window>(w => Close(w, true), w => w != null);
        }

        private void PlusCount(object obj)
        {
            if (Count >= 99)
                return;

            Count++;
        }

        private void MinusCount(object obj)
        {
            if (Count <= 1)
                return;

            Count--;
        }

        private void Close(Window w, bool result)
        {
            w.DialogResult = result;
            w.Close();
        }

        /* BasketItem 생성기 */
        public BasketItem ToBasketItem() =>
            new()
            {
                Drink = Drink,
                Size = SelectedSize,
                Temperature = SelectedTemperature,
                Count = this.Count
            };

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
