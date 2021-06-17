using System.Collections.Generic;
using Trainline.CurrencyConvertor.Domain;

namespace Trainline.CurrencyConvertor.Services
{
    public interface IExchangeRateProvider
    {
        List<Price> GetLatestExchangeRate(Currency currency);
    }
}