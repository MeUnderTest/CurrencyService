using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyService.Models
{
    public interface IRateHistory
    {
        string GetCurrencyName();
        double GetCurrencyValue();
        string GetCurrencyService();
    }
}
