using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Trainline.CurrencyConvertor.Domain
{
    [ImmutableObject(true)]
    public sealed class Currency
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

        #region Equality members

        private bool Equals(Currency other)
        {
            return CurrencyIso == other.CurrencyIso;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Currency other && Equals(other);
        }

        public override int GetHashCode()
        {
            return CurrencyIso.GetHashCode();
        }

        public static bool operator ==(Currency left, Currency right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Currency left, Currency right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}