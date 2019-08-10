using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CurrencyService.Models.YahooModel
{
    public class YahooRateResponse : RateHistoryResponseBase
    {
        private string _provider;
        private string _currencyName;

        [JsonProperty("data")]
        public responseData data { get; set; }
        [IgnoreDataMember]
        public override float CurrencyValue { get => data.CurrentInterbankRate;}
        [IgnoreDataMember]
        public override string CurrencyName { get => this._currencyName; }
        [IgnoreDataMember]
        public override string CurrencyService { get => this._provider; }

        public YahooRateResponse(string provider, string currencyName)
        {
            this._provider = provider;
            this._currencyName = currencyName;
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
}