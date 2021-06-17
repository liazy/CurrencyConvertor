using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Trainline.CurrencyConvertor.Infrastructure
{
    public class ExchangeRateResponse
    {
        [JsonPropertyName("rates")]
        public Dictionary<string, decimal> Rates { get; set; }
    }
}