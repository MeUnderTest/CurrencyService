using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyService.Models
{
    public class RateHistoryRequest : RateHistoryRequestBase
    {
        public string method { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string @base { get; set; }
        public string term { get; set; }
        public string period { get; set; }
    }
}