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
    public class MenuSelectionPageViewModel : INotifyPropertyChanged
    {
        public CafeHomeVIewModel CafeHome { get; set; }

        public CategoryViewModel CategoryVM { get; }
        public MenuSelectionViewModel DrinkSelectionVM { get; }
        public BasketViewModel BasketVM { get; }

        public TrainingManager TrainingManager { get; }


        public MenuSelectionPageViewModel(CafeHomeVIewModel homeVM, TrainingManager trainingManager)
        {
            CafeHome = homeVM;
            TrainingManager = trainingManager;

            BasketVM = new BasketViewModel(CafeHome, this, TrainingManager);
            DrinkSelectionVM = new MenuSelectionViewModel(BasketVM, TrainingManager);
            CategoryVM = new CategoryViewModel(DrinkSelectionVM, TrainingManager);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
