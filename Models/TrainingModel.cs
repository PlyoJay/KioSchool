using KioSchool.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioSchool.Models
{
    public class TrainingStep
    {
        public string Instruction { get; set; }         // 예: "아메리카노를 선택하세요"
        public string ExpectedAction { get; set; }      // 예: "SelectDrink:Americano"
        public string Feedback { get; set; }            // 예: "잘하셨습니다!"
    }

    public static class TrainingContext
    {
        public static TrainingManager Instance { get; set; }
    }
}
