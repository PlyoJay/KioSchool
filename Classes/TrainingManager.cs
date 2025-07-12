using KioSchool.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KioSchool.Classes
{
    public class TrainingManager : INotifyPropertyChanged
    {
        public ObservableCollection<TrainingStep> Steps { get; set; }
        public int CurrentStepIndex { get; private set; }
        public TrainingStep CurrentStep => Steps.ElementAtOrDefault(CurrentStepIndex);

        public void LoadSampleScenario()
        {
            Steps = new ObservableCollection<TrainingStep>
        {
            new TrainingStep { Instruction = "아메리카노를 선택하세요", ExpectedAction = "SelectDrink:Americano", Feedback = "좋아요!" },
            // ... 생략
        };
            CurrentStepIndex = 0;
            OnPropertyChanged(nameof(CurrentStep));
        }

        public bool CheckAction(string action)
        {
            if (CurrentStep?.ExpectedAction == action)
            {
                MessageBox.Show(CurrentStep.Feedback, "정답");
                CurrentStepIndex++;
                OnPropertyChanged(nameof(CurrentStep));
                return true;
            }
            else
            {
                MessageBox.Show("다시 시도해보세요!", "오답");
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
