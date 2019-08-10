using CurrencyService.Models.Enumerations;
using CurrencyService.Models.YahooModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyService.Models
{
    public class RateHistoryResponseFactory
    {
        public static RateHistoryResponseBase CreateRateResponse(provider currencyProvder, currency termCurrency, currency baseCurrency)
        {

            if (currencyProvder == provider.Yahoo)
            {
                return new YahooRateResponse(currencyProvder.ToString(),$"{baseCurrency}/{termCurrency}");
            }
            else
            {
                return null;
            }

        }

        public static RateHistoryResponseBase DeserializeResponse(provider currencyProvder, string jsonResponse) {

            if (currencyProvder == provider.Yahoo)
            {
                return JsonConvert.DeserializeObject <YahooRateResponse> (jsonResponse);
            }
            else { return null; }
        }
    }
}