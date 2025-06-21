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
        public double Price { get; set; }
        public DrinkType DrinkType { get; set; }
        public List<DrinkSize> Sizes { get; set; }
        public List<DrinkTemperature> DrinkTemperatures { get; set; }

        public Drink(int id, string name, double price, DrinkType drink, List<DrinkSize> drinkSizes, List<DrinkTemperature> drinkTemperatures)
        {
            Id = id;
            Name = name;
            Price = price;
            DrinkType = drink;
            Sizes = drinkSizes;
            DrinkTemperatures = drinkTemperatures;
        }
    }
}
