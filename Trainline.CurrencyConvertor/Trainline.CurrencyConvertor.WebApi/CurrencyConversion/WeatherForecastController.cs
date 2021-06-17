using System.ComponentModel.DataAnnotations;
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
        private readonly ILogger<CurrencyConversionController> _logger;
        private readonly CurrencyConversionService _currencyConversionService;

        public CurrencyConversionController(ILogger<CurrencyConversionController> logger, CurrencyConversionService currencyConversionService)
        {
            _logger = logger;
            _currencyConversionService = currencyConversionService;
        }

        [HttpPost]
        public async Task<CurrencyConversionResponse> Post(CurrencyConversionRequest request)
        {
            Price convertedPrice = await _currencyConversionService.ConvertPrice(request.FromPrice, request.TargetCurrencyIso);
            return new CurrencyConversionResponse(convertedPrice);
        }
    }

    public class CurrencyConversionResponse
    {
        public CurrencyConversionResponse(Price price)
        {
            Price = price;
        }

        public Price Price { get; }
    }

    public class CurrencyConversionRequest
    {
        /// <summary>
        /// The price to convert to the given currency.
        /// </summary>
        [Required]
        public Price FromPrice { get; set; }
        
        /// <summary>
        /// The ISO of the currency that will be returned in the response.
        /// </summary>
        [Required]
        public Currency TargetCurrencyIso{ get; set; }
    }
}
