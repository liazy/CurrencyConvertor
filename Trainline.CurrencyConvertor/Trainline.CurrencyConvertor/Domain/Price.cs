using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Trainline.CurrencyConvertor.Domain
{
    public sealed record Price
    {
        #region Constants

        public static Price OnePound = new Price(Currency.GBP, 1);

        #endregion

        public Price(Currency currency, decimal amount)
        {
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            Amount = amount;
        }

        [NotNull]
        [Required]
        public Currency Currency { get; }

        [Required]
        public decimal Amount { get; }

        public override string ToString()
        {
            return $"{nameof(Currency)}: {Currency}, {nameof(Amount)}: {Amount}";
        }
    }
}