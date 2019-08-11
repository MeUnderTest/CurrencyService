using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurrencyService.Models.Enumerations;
using System.Runtime.Serialization;

namespace CurrencyService.Models
{
    public class YahooRateRequest : RateHistoryRequestBase
    {
#pragma warning disable IDE1006

        [IgnoreDataMember]
        public override currency baseRate { get; }
        [IgnoreDataMember]
        public override currency termRate { get; }
        [IgnoreDataMember]
        public override Uri providerUrl { get {return Properties.Settings.Default.YahooUrlSetting; } }
        [IgnoreDataMember]
        public override provider providerName { get; }

        public YahooRateRequest(provider provider, currency baseRate, currency termRate)
        {
            this.providerName = provider;
            this.baseRate = baseRate;
            this.termRate = termRate;
        }

        public string method { get; set; }
        public Data data { get; set; }
        
    }
    public class Data
    {
        public string @base { get; set; }
        public string term { get; set; }
        public string period { get; set; }
    }
#pragma warning restore IDE1006

}