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
        public MenuSelectorViewModel MenuSelectorVM { get; }
        public BasketViewModel BasketVM { get; }

        public OrderViewModel()
        {
            BasketVM = new BasketViewModel();
            MenuSelectorVM = new MenuSelectorViewModel(BasketVM);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
