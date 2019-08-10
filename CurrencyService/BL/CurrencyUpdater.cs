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

        public static async System.Threading.Tasks.Task UpdateCurrenciesAsync(provider providerName)
        {

            //List<RateHistoryRequestBase> requests = new List<RateHistoryRequestBase>() {
            //    RateHistoryRequestFactory.CreateRateHistory(currency.ILS, currency.USD,providerName),
            //    RateHistoryFactory.CreateRateHistory(RateHistoryFactory.currency.EUR, RateHistoryFactory.currency.USD)
            //};

            //Parallel.ForEach(requests, request =>
            //{
            //    Task.Factory.StartNew(() => SingleHttpClientInstance.PostStreamAsync(request, url, cancellationTokenSource.Token), cancellationTokenSource.Token);
            //});

            //RateHistoryResponseBase rateResponse = RateHistoryResponseFactory.DeserializeResponse(providerName, content.termRate, content.baseRate);

            //// Save to DB
            //await CurrencyBL.AddCurrencyAsync(rateResponse.CurrencyName, rateResponse.CurrencyService, rateResponse.CurrencyValue);
        }

        private void PersistRateChangesInParallel(List<RateHistoryRequestBase> rateRequests)
        {
            //Parallel.ForEach(
            //    rateRequests,
            //    new ParallelOptions { MaxDegreeOfParallelism = 10 },
            //    rateRequest =>
            //    {
            //        try
            //        {
            //            using (var transactionScope = new TransactionScope(
            //                TransactionScopeOption.Required,
            //                new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
            //            {
            //                var dbContext = dbContextFactory.CreatedbContext();
            //                foreach (var Product in productsChunk)
            //                {
            //                    dbContext.products.Attach(Product);
                                
            //                }
            //                dbContext.SaveChanges();
            //                transactionScope.Complete();
            //            }
            //        }
            //        catch (Exception e)
            //        {
                        
            //            throw new ApplicationException("Some items might not be updated", e);
            //        }
            //    });
        }
    }
}