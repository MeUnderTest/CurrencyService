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
        public static RateHistoryResponseBase CreateRateResponse(provider currencyProvder)
        {

            if (currencyProvder == provider.Yahoo)
            {
                return new YahooRateResponse();
            }
            else
            {
                return null;
            }

        }

        public static RateHistoryResponseBase DeserializeResponse(provider currencyProvder, currency termCurrency, currency baseCurrency,string jsonResponse) {

            if (currencyProvder == provider.Yahoo)
            {
                YahooRateResponse YahooResponse =  JsonConvert.DeserializeObject<YahooRateResponse>(jsonResponse);
                YahooResponse.CurrencyName = $"{baseCurrency}/{termCurrency}";
                return YahooResponse;
            }
            else { return null; }
        }
    }
}