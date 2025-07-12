using KioSchool.Classes;
using KioSchool.ViewModel.Cafe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace KioSchool.ViewModel
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        public CafeHomeVIewModel CafeHome { get; set; }

        public CategoryViewModel CategoryVM { get; }
        public DrinkSelectionViewModel DrinkSelectionVM { get; }
        public BasketViewModel BasketVM { get; }

        public TrainingManager TrainingManager { get; }


        public OrderViewModel(CafeHomeVIewModel homeVM, TrainingManager trainingManager)
        {
            CafeHome = homeVM;
            TrainingManager = trainingManager;

            BasketVM = new BasketViewModel(CafeHome, this, TrainingManager);
            DrinkSelectionVM = new DrinkSelectionViewModel(BasketVM, trainingManager);
            CategoryVM = new CategoryViewModel(DrinkSelectionVM);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
