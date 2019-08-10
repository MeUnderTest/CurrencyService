using CurrencyService.Models;
using CurrencyService.Models.Enumerations;

namespace CurrencyService.BL
{
    public class RateHistoryRequestFactory
    {
        public static RateHistoryRequestBase CreateRateHistory(currency termCurrency, currency baseCurrency, provider currencyProvder)
        {

            if (currencyProvder == provider.Yahoo)
            {
                return new YahooRateRequest(currencyProvder, baseCurrency, termCurrency)
                {
                    method = "spotRateHistory",
                    data = new Data()
                    {
                        period = rateHistoyPeriod.day.ToString(),
                        term = termCurrency.ToString(),
                        @base = baseCurrency.ToString()
                    }
                };
            }
            else
            {
                return null;
            }

        }
    }
}