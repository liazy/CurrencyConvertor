using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Trainline.CurrencyConvertor.Domain;
using Trainline.CurrencyConvertor.Services;

namespace Trainline.CurrencyConvertor.Infrastructure
{
    public class ExchangeRateService : IExchangeRateProvider
    {
        private readonly ExchangeRateServiceConfig _config;

        public ExchangeRateService(ExchangeRateServiceConfig config)
        {
            _config = config;
        }

        public async Task<ExchangeRateInfo> GetLatestExchangeRates(Currency currency)
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = _config.WebServiceBaseAddress;
                string responseBody =
                    await webClient.GetStringAsync($"/exchangerates/api/latest/{currency.CurrencyIso}.json");

                // TODO - check status codes for error, null checks etc...
                var responseObject = JsonSerializer.Deserialize<ExchangeRateResponse>(responseBody);

                var exchangeRates = responseObject.Rates
                                                       .Select(r => new Price(new Currency(r.Key), r.Value))
                                                       .ToList();
                return new ExchangeRateInfo(exchangeRates);
            }
        }

        public class ExchangeRateServiceConfig
        {
            public ExchangeRateServiceConfig(Uri webServiceBaseAddress)
            {
                WebServiceBaseAddress = webServiceBaseAddress;
            }

            public Uri WebServiceBaseAddress { get; }
        }
    }

    public class ExchangeRateResponse
    {
        public Dictionary<string, decimal> Rates { get; set; }
    }
}