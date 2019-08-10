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
            // Update DB

            IEnumerable<CurrencyDO> Currencies = await CurrencyDAL.GetCurrenciesAsync(provider);

            return Currencies.Select(x => new CurrencyBO() {
                CurrencyLastUpdate = x.CurrencyLastUpdate,
                CurrencyName = x.CurrencyName,
                CurrencyService = x.CurrencyService,
                CurrencyValue = x.CurrencyValue
            }).ToList();
        }
    }
}