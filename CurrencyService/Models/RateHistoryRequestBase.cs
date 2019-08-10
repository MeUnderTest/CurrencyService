using CurrencyService.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyService.Models
{
    public abstract class RateHistoryRequestBase
    {
        abstract public currency baseRate { get;}
        abstract public currency termRate { get;}
        abstract public Uri providerUrl { get; }
        abstract public provider providerName { get; }
    }
}