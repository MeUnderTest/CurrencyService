using CurrencyService.BL;
using CurrencyService.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CurrencyService.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("api/GetCurrency")]
        public async Task<IHttpActionResult> GetAsync()
        {
            IEnumerable<CurrencyBO> CurrencyBOList = await CurrencyBL.GetCurrenciesAsync(Properties.Settings.Default.ProviderSetting);

            if (!CurrencyBOList.Any()) return NotFound();

            return Ok<List<string>>(new List<string>());
        }

    }
}
