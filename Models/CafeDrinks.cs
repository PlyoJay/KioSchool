using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioSchool.Models
{
    public static class CafeDrinks
    {
        public static ObservableCollection<Drink> SetCoffeeList()
        {
            ObservableCollection<Drink> coffeeList = new ObservableCollection<Drink>()
            {
                new(1, "아메리카노", 1600, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    "/Resources/Images/Cafe/IcedAmericano.png"),
                new(2, "카페라떼", 1900, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(3, "바닐라라떼", 2100, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(4, "카푸치노", 2100, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(5, "카페모카", 2200, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(6, "콜드브루", 1800, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    ""),
                new(7, "콜드브루 라떼", 2100, DrinkType.Coffee,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    ""),
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
                    "/Resources/Images/Cafe/IcedAmericano.png"),
                new(9, "복숭아 아이스티", 1800, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced},
                    ""),
                new(10, "페퍼민트 티", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(11, "캐모마일 티", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(12, "얼그레이 티", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(13, "히비스커스 티", 2100, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(14, "유자 민트 티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(14, "애플 민트 티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Iced, DrinkTemperature.Hot},
                    ""),
                new(15, "진저티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Hot},
                    ""),
                new(15, "로얄 밀크티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Hot, DrinkTemperature.Iced},
                    ""),
                new(15, "로얄 밀크티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Hot, DrinkTemperature.Iced},
                    ""),
                new(15, "로얄 밀크티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Hot, DrinkTemperature.Iced},
                    ""),
                new(15, "로얄 밀크티", 2300, DrinkType.Tea,
                    new List<DrinkSize>{DrinkSize.Regular, DrinkSize.Large},
                    new List<DrinkTemperature>{DrinkTemperature.Hot, DrinkTemperature.Iced},
                    ""),
            };
        }
    }
}
