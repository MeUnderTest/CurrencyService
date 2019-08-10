using CurrencyService.Models.Enumerations;
using System;

namespace CurrencyService.DAL.Model
{
    public class CurrencyDO
    {
        public string CurrencyName { get; set; }
        public string CurrencyValue { get; set; }
        public DateTime? CurrencyLastUpdate { get; set; }
        public provider CurrencyService { get; set; }
    }
}