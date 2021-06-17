using System.Collections.Generic;
using System.Linq;
using Trainline.CurrencyConvertor.Domain;
using Trainline.CurrencyConvertor.Services;

namespace Trainline.CurrencyConvertor.UnitTests.TestBed
{
    public class ExchangeRateProviderMock : IExchangeRateProvider
    {
        private readonly List<Price> _prices;

        public ExchangeRateProviderMock(List<Price> prices = null)
        {
            _prices = prices ?? new List<Price>
            {
                new Price(Currency.GBP, 1)
            };
        }

        public List<Price> GetLatestExchangeRate(Currency currency)
        {
            // return a new list each time...
            return _prices.ToList();
        }
    }
}