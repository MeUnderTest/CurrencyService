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

        public static void AddCurrency(string currencyName, string currencyService, double currencyValue)
        {
            using (var context = new CurrencyEntities())
            {
                var result = context.Currencies.Where(x => x.CurrencyName == currencyName && x.CurrencyService == currencyService).FirstOrDefault();

                if (result != null)
                {
                    result.CurrencyLastUpdate = DateTime.Now;
                    result.CurrencyValue = currencyValue;
                }
                else
                {
                    context.Currencies.Add(new Currency()
                    {
                        CurrencyLastUpdate = DateTime.Now,
                        CurrencyName = currencyName,
                        CurrencyService = currencyService,
                        CurrencyValue = currencyValue
                    });
                }

                context.SaveChanges();
            }
        }
    }


}