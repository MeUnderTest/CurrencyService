using CurrencyService.Models.Enumerations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CurrencyService.Models.YahooModel
{
#pragma warning disable IDE1006

    public class YahooRateResponse : RateHistoryResponseBase, IRateHistory
    {
        public string CurrencyName { get;  set; }

        [JsonProperty("data")]
        public responseData data { get; set; }

        public override string GetCurrencyName()
        {
            return CurrencyName;
        }

        public override double GetCurrencyValue()
        {
            return data.CurrentInterbankRate;
        }

        public override string GetCurrencyService()
        {
            return provider.Yahoo.ToString();
        }

    }

    public class responseData
    {
        public float CurrentInterbankRate { get; set; }
        public float CurrentInverseInterbankRate { get; set; }
        public float Average { get; set; }
        public Historicalpoint[] HistoricalPoints { get; set; }
        public bool supportedByOfx { get; set; }
        public long fetchTime { get; set; }
    }

    public class Historicalpoint
    {
        public long PointInTime { get; set; }
        public float InterbankRate { get; set; }
        public float InverseInterbankRate { get; set; }
    }
#pragma warning restore IDE1006

}