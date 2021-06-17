using System;
using System.Linq;
using System.Threading.Tasks;
using Trainline.CurrencyConvertor.Domain;

namespace Trainline.CurrencyConvertor.Services
{
    public class CurrencyConversionService
    {
        private readonly IExchangeRateProvider _exchangeRateProvider;

        public CurrencyConversionService(IExchangeRateProvider exchangeRateProvider)
        {
            _exchangeRateProvider = exchangeRateProvider;
        }

        public async Task<Price> ConvertPrice(Price price, Currency targetCurrency)
        {
            var latestExchangeRates = await _exchangeRateProvider.GetLatestExchangeRates(price.Currency);
            var exchangeRate = latestExchangeRates.Prices.FirstOrDefault(p => p.Currency == targetCurrency);
            if (exchangeRate == null)
                throw new ArgumentException("The target currency is not supported", nameof(targetCurrency));

            return new Price(exchangeRate.Currency, exchangeRate.Amount * price.Amount);
        }
    }
}