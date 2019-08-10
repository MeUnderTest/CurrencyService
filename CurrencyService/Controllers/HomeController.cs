using CurrencyService.BL;
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
        public IHttpActionResult Get()
        {
            CurrencyBL.GetCurrenciesAsync(Properties.Settings.Default.ProviderSetting);

            if (false) return NotFound();

            return Ok<List<string>>(new List<string>());
        }

    }
}
