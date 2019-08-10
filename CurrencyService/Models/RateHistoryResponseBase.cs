using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyService.Models
{
    public abstract class RateHistoryResponseBase
    {
        abstract public string CurrencyName { get;}
        abstract public float CurrencyValue { get;}
        abstract public string CurrencyService { get;}
    }
}