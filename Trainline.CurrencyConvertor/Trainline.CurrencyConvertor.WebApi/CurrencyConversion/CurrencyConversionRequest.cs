using System.ComponentModel.DataAnnotations;
using Trainline.CurrencyConvertor.Domain;

namespace Trainline.CurrencyConvertor.WebApi.CurrencyConversion
{
    public class CurrencyConversionRequest
    {
        /// <summary>
        ///     The price to convert to the given currency.
        /// </summary>
        [Required]
        public Price FromPrice { get; set; }

        /// <summary>
        ///     The ISO of the currency that will be returned in the response.
        /// </summary>
        [Required]
        public Currency TargetCurrencyIso { get; set; }
    }
}