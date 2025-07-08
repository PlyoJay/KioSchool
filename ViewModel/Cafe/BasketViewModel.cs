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

namespace KioSchool.ViewModel
{
    public class BasketViewModel : INotifyPropertyChanged
    {
        public Basket Basket { get; } = new();

        public ObservableCollection<BasketItem> Items => Basket.Items;

        public int TotalPrice => Basket.TotalPrice;
        public int TotalCount => Basket.TotalCount;

        public ICommand MinusCommand { get; }
        public ICommand PlusCommand { get; }
        public ICommand RemoveCommand { get; }

        public BasketViewModel()
        {
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
                    item.Count = Math.Min(99, item.Count + 1);
                    AddDrink(item, item.Count);
                }
            });

            RemoveCommand = new RelayCommand(obj =>
            {
                if (obj is BasketItem item)
                {
                    Basket.Items.Remove(item);
                    OnPropertyChanged(nameof(Items));
                    OnPropertyChanged(nameof(TotalPrice));
                    OnPropertyChanged(nameof(TotalCount));
                }
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
