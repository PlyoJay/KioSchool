using KioSchool.Classes;
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
    public class CafeHomeVIewModel : INotifyPropertyChanged
    {
        public TrainingManager _trainingManager { get; }

        public ICommand ToOrderCommand { get; }

        public CafeHomeVIewModel(TrainingManager trainingManager)
        {
            _trainingManager = trainingManager;

            ToOrderCommand = new RelayCommand(ToOrderPage);
        }

        private void ToOrderPage(object paramenter)
        {
            string tag = (string)paramenter;

            if (_trainingManager.GetIsTrainingMode())
            {
                string actionKey = $"SelectHow:{tag}";
                if (!_trainingManager.CheckAction(actionKey))
                    return;
            }

            CafeOrderType orderType = (CafeOrderType)Enum.Parse(typeof(CafeOrderType), tag);
            Enums.SetCafeOrderType(orderType);        
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
