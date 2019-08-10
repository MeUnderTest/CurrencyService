using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static CurrencyService.Models.Enumerations;

namespace CurrencyService.Models
{
    public class CurrencyProvider
    {
        public provider Provider { get; set;}
        public Uri providerUrl { get; set; }
    }
}