using KioSchool.Controls;
using KioSchool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace KioSchool.ViewModel
{
    class CafeHomeVIewModel : INotifyPropertyChanged
    {
        public ICommand ToOrderCommand { get; }

        public CafeHomeVIewModel()
        {
            ToOrderCommand = new RelayCommand(ToOrderPage);
        }

        private void ToOrderPage(object paramenter)
        {
            string tag = (string)paramenter;
            CafeOrderType orderType = (CafeOrderType)Enum.Parse(typeof(CafeOrderType), tag);
            Enums.SetCafeOrderType(orderType);        
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
