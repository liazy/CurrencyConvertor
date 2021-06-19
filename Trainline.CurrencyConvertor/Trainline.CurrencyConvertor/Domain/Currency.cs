using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Trainline.CurrencyConvertor.Domain
{
    public sealed record Currency
    {
        public Currency(string currencyIso)
        {
            if (currencyIso == null) throw new ArgumentNullException(nameof(currencyIso));

            // TODO - double check rule and add other validation if needed.
            if (currencyIso.Length != 3)
                throw new ArgumentException("Parameter is not an currency ISO", nameof(currencyIso));

            CurrencyIso = currencyIso.ToUpperInvariant();
        }

        [NotNull]
        [Required]
        public string CurrencyIso { get; }

        public override string ToString()
        {
            return $"{nameof(CurrencyIso)}: {CurrencyIso}";
        }

        #region Constants

        public static Currency GBP = new Currency("GBP");
        public static Currency EUR = new Currency("EUR");
        public static Currency USD = new Currency("USD");

        #endregion
    }
}