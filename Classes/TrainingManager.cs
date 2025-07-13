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
        
        private bool IsTrainingMode { get; set; }

        public void LoadSampleScenario()
        {
            IsTrainingMode = true;

            Steps = new ObservableCollection<TrainingStep>
            {
                new TrainingStep { Instruction = "매장을 선택하세요", ExpectedAction = "SelectHow:ForHere", Feedback = "좋아요!" },
                new TrainingStep { Instruction = "아메리카노를 선택하세요", ExpectedAction = "SelectDrink:아메리카노", Feedback = "좋아요!" },
                new TrainingStep { Instruction = "핫을 선택하세요", ExpectedAction = "SelectTemperature:Hot", Feedback = "좋아요!" },
                new TrainingStep { Instruction = "라지를 선택하세요", ExpectedAction = "SelectSize:Large", Feedback = "좋아요!" },
                new TrainingStep { Instruction = "선택완료를 클릭하세요", ExpectedAction = "Click:True", Feedback = "좋아요!" },
                new TrainingStep { Instruction = "요거트 카테고리를 클릭하세요", ExpectedAction = "SelectCategory:요거트", Feedback = "좋아요!" },
                new TrainingStep { Instruction = "블루베리스무디를 선택하세요", ExpectedAction = "SelectDrink:블루베리스무디", Feedback = "좋아요!" },
                new TrainingStep { Instruction = "2개로 올리세요", ExpectedAction = "AddCount", Feedback = "좋아요!" },
                new TrainingStep { Instruction = "선택완료를 클릭하세요", ExpectedAction = "Click:True", Feedback = "좋아요!" },
                new TrainingStep { Instruction = "아메리카노를 2개로 올리세요", ExpectedAction = "AddCount:아메리카노", Feedback = "좋아요!" },
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

                if (CurrentStepIndex >= Steps.Count)
                {
                    MessageBox.Show("훈련을 성공적으로 완수하였습니다!", "완료");
                    CurrentStep.Instruction = "[훈련 완수]";
                    IsTrainingMode = false;
                    return true;
                }

                CurrentStep.Instruction = "[다음 단계] " + CurrentStep.Instruction;

                var newStep = Steps[CurrentStepIndex];
                Steps[CurrentStepIndex] = new TrainingStep
                {
                    Instruction = newStep.Instruction,
                    ExpectedAction = newStep.ExpectedAction,
                    Feedback = newStep.Feedback
                };

                OnPropertyChanged(nameof(CurrentStep));
                OnPropertyChanged(nameof(CurrentStepIndex));
                return true;
            }
            else
            {
                MessageBox.Show("다시 시도해보세요!", "오답");
                return false;
            }
        }

        public bool CheckCurrentStepIndex(int index)
        {
            if (CurrentStepIndex != index)
            {
                MessageBox.Show("다시 시도해보세요!", "오답");
                return false;
            }

            return true;
        }

        public bool GetIsTrainingMode()
        {
            return IsTrainingMode;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
