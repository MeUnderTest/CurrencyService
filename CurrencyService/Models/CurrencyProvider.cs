using CurrencyService.Models.Enumerations;
using System;


namespace CurrencyService.Models
{
    public class CurrencyProvider
    {
        public provider Provider { get; set;}
        public Uri providerUrl { get; set; }
    }
}