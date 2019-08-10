using CurrencyService.DAL.Model;
using CurrencyService.Models.Enumerations;
using CurrencyService.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyService.DAL
{
    public class CurrencyDAL
    {
        public static async Task<IEnumerable<CurrencyDO>> GetCurrenciesAsync(provider provider)
        {
            using (var context = new CurrencyEntities())
            {
                List<Currency> Currencies = await context.Currencies
                                   .Where(x => x.CurrencyService == provider.ToString())
                                   .ToListAsync();

                return Currencies.Select(x => new CurrencyDO() {
                    CurrencyLastUpdate = x.CurrencyLastUpdate,
                    CurrencyName = x.CurrencyName,
                    CurrencyService = EnumUtility.ToEnum<provider>(x.CurrencyService),
                    CurrencyValue = x.CurrencyValue
                }).ToList();
            }

        }

        public static async Task AddCurrencyAsync(string currencyName, string currencyService, float currencyValue)
        {
            using (var context = new CurrencyEntities())
            {

                context.Currencies.Add(new Currency() {
                    CurrencyLastUpdate = DateTime.Now,
                    CurrencyName = currencyName,
                    CurrencyService = currencyService,
                    CurrencyValue = currencyValue
                });
                await context.SaveChangesAsync();
            }
        }
    }


}