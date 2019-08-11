using CurrencyService.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyService.BL.Model
{
    public class CurrencyBO
    {
        public string CurrencyName { get; set; }
        public double CurrencyValue { get; set; }
        public DateTime? CurrencyLastUpdate { get; set; }
        public provider CurrencyService { get; set; }
    }
}