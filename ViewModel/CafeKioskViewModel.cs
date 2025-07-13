using KioSchool.Classes;
using KioSchool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KioSchool.ViewModel
{
    public class CafeKioskViewModel : INotifyPropertyChanged
    {
        public TrainingManager TrainingManager { get; }

        public CafeHomeVIewModel CafeHomeVM { get; }
        public MenuSelectionPageViewModel MenuSelectionPageVM { get; }

        public CafeKioskViewModel()
        {
            TrainingManager = new TrainingManager();
            TrainingManager.LoadSampleScenario();

            CafeHomeVM = new CafeHomeVIewModel(TrainingManager);
            MenuSelectionPageVM = new MenuSelectionPageViewModel(CafeHomeVM, TrainingManager);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
