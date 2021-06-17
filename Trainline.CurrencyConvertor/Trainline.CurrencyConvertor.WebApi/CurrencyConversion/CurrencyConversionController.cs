using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trainline.CurrencyConvertor.Domain;
using Trainline.CurrencyConvertor.Services;

namespace Trainline.CurrencyConvertor.WebApi.CurrencyConversion
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyConversionController : ControllerBase
    {
        private readonly CurrencyConversionService _currencyConversionService;
        private readonly ILogger<CurrencyConversionController> _logger;

        public CurrencyConversionController(ILogger<CurrencyConversionController> logger,
                                            CurrencyConversionService currencyConversionService)
        {
            _logger = logger;
            _currencyConversionService = currencyConversionService;
        }

        [HttpPost]
        public async Task<CurrencyConversionResponse> Post(CurrencyConversionRequest request)
        {
            Price convertedPrice =
                await _currencyConversionService.ConvertPrice(request.FromPrice, request.TargetCurrencyIso);
            return new CurrencyConversionResponse(convertedPrice);
        }
    }
}