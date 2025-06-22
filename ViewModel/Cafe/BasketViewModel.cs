using KioSchool.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KioSchool.ViewModel
{
    public class BasketViewModel : INotifyPropertyChanged
    {
        public Basket Basket { get; } = new();

        public ObservableCollection<BasketItem> Items => Basket.Items;

        public void AddDrink(BasketItem item, int count = 1)
        {
            Basket.AddDrink(item, count);
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(TotalPrice));
        }

        public int TotalPrice => Basket.TotalPrice;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
