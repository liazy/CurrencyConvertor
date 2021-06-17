using Trainline.CurrencyConvertor.Domain;

namespace Trainline.CurrencyConvertor.WebApi.CurrencyConversion
{
    public class CurrencyConversionResponse
    {
        public CurrencyConversionResponse(Price price)
        {
            Price = price;
        }

        public Price Price { get; }
    }
}