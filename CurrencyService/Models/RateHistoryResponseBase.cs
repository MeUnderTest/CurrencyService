using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyService.Models
{
    public class RateHistoryResponseBase : IRateHistory
    {
        virtual public string GetCurrencyName()
        {
            throw new NotImplementedException();
        }

        virtual public string GetCurrencyService()
        {
            throw new NotImplementedException();
        }

        virtual public double GetCurrencyValue()
        {
            throw new NotImplementedException();
        }
    }
}