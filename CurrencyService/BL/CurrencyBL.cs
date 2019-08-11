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
            CurrencyUpdater.UpdateCurrencies(provider);

            IEnumerable<CurrencyDO> Currencies = await CurrencyDAL.GetCurrenciesAsync(provider);

            return Currencies.Select(x => new CurrencyBO() {
                CurrencyLastUpdate = x.CurrencyLastUpdate,
                CurrencyName = x.CurrencyName,
                CurrencyService = x.CurrencyService,
                CurrencyValue = x.CurrencyValue
            }).ToList();
        }

        public static async Task AddCurrencyAsync(string currencyName, string currencyService, float currencyValue) {

            await CurrencyDAL.AddCurrencyAsync(currencyName, currencyService, currencyValue);
        }
    }
}