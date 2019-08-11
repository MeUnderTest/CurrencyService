using CurrencyService.BL.Model;
using CurrencyService.DAL;
using CurrencyService.DAL.Model;
using CurrencyService.Models.Enumerations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyService.BL
{
    public class CurrencyBL
    {

        public static async Task<IEnumerable<CurrencyBO>> GetCurrenciesAsync(provider provider)
        {
            Task t = Task.Factory.StartNew(() => CurrencyUpdater.UpdateCurrencies(provider) );
            t.Wait();

            IEnumerable<CurrencyDO> Currencies = await CurrencyDAL.GetCurrenciesAsync(provider);

            return Currencies.Select(x => new CurrencyBO() {
                CurrencyLastUpdate = x.CurrencyLastUpdate,
                CurrencyName = x.CurrencyName,
                CurrencyService = x.CurrencyService,
                CurrencyValue = x.CurrencyValue
            }).ToList();
        }

        public static void AddCurrency(string currencyName, string currencyService, double currencyValue) {

            CurrencyDAL.AddCurrency(currencyName, currencyService, currencyValue);
        }

        public static async Task UpdateCurrenciesAsync(provider provider) {
            Task t = Task.Factory.StartNew(() => CurrencyUpdater.UpdateCurrenciesService(provider));
            t.Wait();
        }
    }
}