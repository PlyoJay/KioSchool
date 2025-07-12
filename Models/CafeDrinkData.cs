using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioSchool.Models
{
    public static class CafeDrinkData
    {
        public static ObservableCollection<Drink> SetCoffeeList()
        {
            ObservableCollection<Drink> coffeeList = new ObservableCollection<Drink>()
            {
                new(1, "아메리카노", 1600, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(2, "카페라떼", 1900, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(3, "바닐라라떼", 2100, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(4, "카푸치노", 2100, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(5, "카페모카", 2200, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(6, "콜드브루", 1800, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(7, "콜드브루 라떼", 2100, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
            };
            return coffeeList;
        }

        public static ObservableCollection<Drink> SetTeaList()
        {
            return new ObservableCollection<Drink>()
            {
                new(8, "레몬 아이스티", 1800, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(9, "복숭아 아이스티", 1800, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(10, "페퍼민트 티", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(11, "캐모마일 티", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(12, "얼그레이 티", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(13, "히비스커스 티", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(14, "유자 민트 티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(14, "애플 민트 티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(15, "진저티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Hot},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(16, "로얄 밀크티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Hot, DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png")
            };
        }

        public static ObservableCollection<Drink> SetAdeNJuiceList()
        {
            return new ObservableCollection<Drink>()
            {
                new(17, "레몬에이드", 1800, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(18, "복숭아에이드", 1800, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(19, "자몽에이드", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(20, "청포도에이드", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(21, "사과주스", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(22, "오렌지주스", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(23, "바나나주스", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(24, "블루베리주스", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png")
            };
        }

        public static ObservableCollection<Drink> SetYogurtList()
        {
            return new ObservableCollection<Drink>()
            {
                new(25, "플레인", 1800, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(26, "블루베리", 1800, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(27, "바나나", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(28, "망고", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(29, "사과", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(30, "플레인스무디", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(31, "블루베리스무디", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(32, "바나나스무디", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(33, "망고스무디", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
                new(34, "사과스무디", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    "pack://application:,,,/Resources/Images/Cafe/IcedAmericano.png"),
            };
        }
    }
}
