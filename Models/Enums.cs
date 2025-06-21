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
        Ade,
        Juice
    }

    public enum DrinkSize
    {
        Regular,
        Large
    }

    public enum DrinkTemperature
    {
        Iced,
        Hot
    }

    public static class Enums
    {
        public static CafeOrderType CafeOrderType {  get; set; }

        static Enums()
        {
            CafeOrderType = CafeOrderType.None;
        }

        public static CafeOrderType GetCafeOrderType()
        {
            return CafeOrderType;
        }

        public static void SetCafeOrderType(CafeOrderType orderType)
        {
            Enums.CafeOrderType = orderType;
        }
    }
}
