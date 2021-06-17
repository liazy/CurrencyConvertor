using System.Collections.Generic;
using System.Linq;

namespace Trainline.CurrencyConvertor.Domain
{
    public class ExchangeRateInfo
    {
        public ExchangeRateInfo(IEnumerable<Price> prices)
        {
            // copy the list to make sure it is readonly...
            Prices = prices.ToList();
        }

        public IReadOnlyCollection<Price> Prices { get; }
    }
}