using CurrencyService.BL;
using CurrencyService.BL.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CurrencyService.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("api/GetCurrency")]
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<CurrencyBO> CurrencyBOList = await CurrencyBL.GetCurrenciesAsync(Properties.Settings.Default.ProviderSetting);

            if (!CurrencyBOList.Any()) return NotFound();

            return Ok<IEnumerable<CurrencyBO>>(CurrencyBOList);
        }

        [HttpGet]
        [Route("api/UpdateCurrency")]
        public async Task Update()
        {
            await CurrencyBL.UpdateCurrenciesAsync(Properties.Settings.Default.ProviderSetting);
        }

        /*
         
        Request URL: http://localhost:60463/api/GetCurrency

        Response: 
         
         [
    {
        "CurrencyName": "USD/ILS",
        "CurrencyValue": 3.4449000358581543,
        "CurrencyLastUpdate": "2019-08-11T23:14:13.99",
        "CurrencyService": 0
    },
    {
        "CurrencyName": "USD/EUR",
        "CurrencyValue": 0.89259999990463257,
        "CurrencyLastUpdate": "2019-08-11T23:14:14.347",
        "CurrencyService": 0
    },
    {
        "CurrencyName": "EUR/JPY",
        "CurrencyValue": 118.21308898925781,
        "CurrencyLastUpdate": "2019-08-11T23:14:14.713",
        "CurrencyService": 0
    },
    {
        "CurrencyName": "GBP/EUR",
        "CurrencyValue": 1.0771087408065796,
        "CurrencyLastUpdate": "2019-08-11T23:14:15.08",
        "CurrencyService": 0
    }
]
         
         */
    }
}
