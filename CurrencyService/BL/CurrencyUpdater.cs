using CurrencyService.Models;
using CurrencyService.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

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

            RateChangesParallel(rateRequests);
        }

        private static void RateChangesParallel(List<RateHistoryRequestBase> rateRequests)
        {
            Parallel.ForEach(
                rateRequests,
                new ParallelOptions { MaxDegreeOfParallelism = 10 },
                async rateRequest =>
                {
                    try
                    {
                        using (var transactionScope = new TransactionScope(
                            TransactionScopeOption.Required,
                            new TransactionOptions { IsolationLevel = IsolationLevel.Serializable })){

                            //Task<string> jsonResponse = await Task.Factory.StartNew(() => SingleHttpClientInstance.PostStreamAsync(rateRequest));

                            string jsonResponse = await SingleHttpClientInstance.PostStreamAsync(rateRequest);

                            //if (jsonResponse.IsCompleted)
                            //{
                                RateHistoryResponseBase response=  RateHistoryResponseFactory.DeserializeResponse(rateRequest.providerName, jsonResponse);

                                await CurrencyBL.AddCurrencyAsync(response.CurrencyName.ToString(), response.CurrencyService, response.CurrencyValue);
                            //}

                            transactionScope.Complete();
                        }
                    }
                    catch (Exception e)
                    {

                        throw new ApplicationException("Some items might not be updated", e);
                    }
                });
        }
    }
}