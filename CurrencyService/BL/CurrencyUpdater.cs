using CurrencyService.Models;
using CurrencyService.Models.Enumerations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyService.BL
{
    public class CurrencyUpdater
    {

        public static void UpdateCurrencies(provider providerName)
        {
            // ToDO: this list need to fill dynamiclly from config file
            List<RateHistoryRequestBase> rateRequests = new List<RateHistoryRequestBase>() {
                RateHistoryRequestFactory.CreateRateHistory(currency.ILS, currency.USD,providerName),
                RateHistoryRequestFactory.CreateRateHistory(currency.EUR, currency.USD,providerName),
                RateHistoryRequestFactory.CreateRateHistory(currency.JPY, currency.EUR,providerName),
                RateHistoryRequestFactory.CreateRateHistory(currency.EUR, currency.GBP,providerName)
            };

            rateRequests.ForEach(rateRequest =>
            {
                Task<string> jsonResponseTask = SingleHttpClientInstance.PostStreamAsync(rateRequest);
                jsonResponseTask.Wait();

                if (jsonResponseTask.IsCompleted)
                {
                    RateHistoryResponseBase response = RateHistoryResponseFactory.DeserializeResponse(rateRequest.providerName, rateRequest.termRate, rateRequest.baseRate,jsonResponseTask.Result);

                    CurrencyBL.AddCurrency(response.GetCurrencyName().ToString(), response.GetCurrencyService(), response.GetCurrencyValue());
                }
                
            });
        }

        public static void UpdateCurrenciesService(provider providerName)
        {
            // ToDO: this list need to fill dynamiclly from config file
            List<RateHistoryRequestBase> rateRequests = new List<RateHistoryRequestBase>() {
                RateHistoryRequestFactory.CreateRateHistory(currency.ILS, currency.USD,providerName),
                RateHistoryRequestFactory.CreateRateHistory(currency.EUR, currency.USD,providerName),
                RateHistoryRequestFactory.CreateRateHistory(currency.JPY, currency.EUR,providerName),
                RateHistoryRequestFactory.CreateRateHistory(currency.EUR, currency.GBP,providerName)
            };

            Parallel.ForEach(rateRequests, async rateRequest =>
             {
                 using (var cancellationTokenSource = new CancellationTokenSource())
                 {
                     await SingleHttpClientInstance.stringPostStreamAsync(rateRequest, cancellationTokenSource.Token);
                 }

             });
        }
    }
}