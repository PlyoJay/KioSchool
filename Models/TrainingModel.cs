using KioSchool.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioSchool.Models
{
    public class TrainingStep : INotifyPropertyChanged
    {
        private string _instruction;
        public string Instruction
        {
            get => _instruction;
            set
            {
                if (_instruction != value)
                {
                    _instruction = value;
                    OnPropertyChanged(nameof(Instruction));
                }
            }
        }         // 예: "아메리카노를 선택하세요"
        public string ExpectedAction { get; set; }      // 예: "SelectDrink:Americano"
        public string Feedback { get; set; }            // 예: "잘하셨습니다!"

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public static class TrainingContext
    {
        public static TrainingManager Instance { get; set; }
    }
}
