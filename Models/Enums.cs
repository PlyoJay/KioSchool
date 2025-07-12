using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioSchool.Models
{
    public enum CafeOrderType
    {
        None,
        ForHere,
        ToGo
    }

    public enum DrinkType
    {
        Coffee,
        Tea,
        AdeNJuisce,
        Yogurt
    }

    public enum DrinkSize
    {
        Regular = 0,
        Large = 500
    }

    public enum DrinkTemperature
    {
        Iced,
        Hot
    }

    public static class Enums
    {
        private static CafeOrderType CafeOrderType {  get; set; }
        private static Dictionary<object, string> EnumKor { get; set; }

        static Enums()
        {
            CafeOrderType = CafeOrderType.None;
            SetEnumKor();
        }

        public static CafeOrderType GetCafeOrderType()
        {
            return CafeOrderType;
        }

        public static void SetCafeOrderType(CafeOrderType orderType)
        {
            Enums.CafeOrderType = orderType;
        }

        private static void SetEnumKor()
        {
            if (EnumKor == null) EnumKor = new Dictionary<object, string>();

            EnumKor.Add(DrinkSize.Regular, "레귤러");
            EnumKor.Add(DrinkSize.Large, "라지");
            EnumKor.Add(DrinkTemperature.Iced, "아이스");
            EnumKor.Add(DrinkTemperature.Hot, "핫");
        }

        public static Dictionary<object, string> GetEnumKor() =>
            EnumKor;
    }
}
