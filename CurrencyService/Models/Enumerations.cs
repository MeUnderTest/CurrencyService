using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyService.Models
{
    public class Enumerations
    {
        public enum rateHistoyPeriod
        {
            day,
            week,
            month
        }
        public enum currency
        {
            ILS,
            USD,
            EUR,
            JPY,
            GBP
        }

        public enum provider
        {
            Yahoo,
            Google,
            Bloomberg,
            XE
        }
    }
}