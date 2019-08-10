using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyService.Utilities
{
    public static class EnumUtility
    {
        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}