using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KioSchool.Models
{
    public class Category : INotifyPropertyChanged
    {
        public string Name { get; set; } = string.Empty;
        public string EngName { get; set; } = string.Empty;
        public ObservableCollection<Drink> DrinkList { get; set; }
        public DrinkType DrinkType { get; set; }
        
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public Category(string name, string engName, ObservableCollection<Drink> drinkList, DrinkType drinkType)
        {
            Name = name;
            EngName = engName;
            DrinkList = drinkList;
            DrinkType = drinkType;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public DrinkType DrinkType { get; set; }
        public List<DrinkSize> Sizes { get; set; }
        public List<DrinkTemperature> Temperatures { get; set; }
        public string DrinkImage { get; set; }

        public Drink(int id, string name, int price, 
            DrinkType drink, List<DrinkSize> drinkSizes, 
            List<DrinkTemperature> drinkTemperatures, 
            string drinkImageSource)
        {
            Id = id;
            Name = name;
            Price = price;
            DrinkType = drink;
            Sizes = drinkSizes;
            Temperatures = drinkTemperatures;
            DrinkImage = drinkImageSource;
        }
    }

    public class Basket
    {
        public ObservableCollection<BasketItem> Items { get; set; } = new();

        public int TotalCount => Items.Sum(item => item.Count);
        public int TotalPrice => Items.Sum(item => item.TotalPrice);

        // 항목 추가
        public void AddDrink(BasketItem basketItem, int count = 1)
        {
            var existingItem = FindItemInBasket(basketItem);

            if (existingItem == null)
            {
                basketItem.Count = count;
                Items.Add(basketItem);
            }
            else
            {
                existingItem.Count += count;
            }
        }

        // 개수 감소 (0이면 제거)
        public void DecreaseDrink(BasketItem basketItem, int count = 1)
        {
            var existingItem = FindItemInBasket(basketItem);
            if (existingItem == null)
                return;

            existingItem.Count -= count;

            // 0 이하인 경우 삭제
            if (existingItem.Count <= 0)
                Items.Remove(existingItem);
        }

        // 항목 제거
        public void RemoveDrink(BasketItem basketItem)
        {
            var existingItem = FindItemInBasket(basketItem);
            if (existingItem != null)
                Items.Remove(existingItem);
        }

        private BasketItem? FindItemInBasket(BasketItem basketItem)
        {
            return Items.FirstOrDefault(d =>
                d.Drink.Name == basketItem.Drink.Name &&
                d.Temperature == basketItem.Temperature &&
                d.Size == basketItem.Size);
        }

        // 전체 초기화
        public void Clear()
        {
            Items.Clear();
        }
    }

    public class BasketItem
    {
        public Drink Drink { get; set; }
        public DrinkSize Size { get; set; }
        public DrinkTemperature Temperature { get; set; }
        public int Count { get; set; }
        public int TotalPrice => Count * (Drink.Price + (int)Size);
    }
}
