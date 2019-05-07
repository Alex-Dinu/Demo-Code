using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.ExchangeRates
{
    public class ExchangeRateApplicationApiResponseModel
    {

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}