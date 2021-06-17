using System.Threading.Tasks;
using Trainline.CurrencyConvertor.Domain;

namespace Trainline.CurrencyConvertor.Services
{
    public interface IExchangeRateProvider
    {
        Task<ExchangeRateInfo> GetLatestExchangeRates(Currency currency);
    }
}