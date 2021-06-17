using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Trainline.CurrencyConvertor.Domain
{
    [ImmutableObject(true)]
    public sealed class Price
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
        public Currency Currency { get; }
        public decimal Amount { get; }

        #region Equality members

        private bool Equals(Price other)
        {
            return Currency.Equals(other.Currency) && Amount == other.Amount;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Price other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Currency, Amount);
        }

        public static bool operator ==(Price left, Price right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Price left, Price right)
        {
            return !Equals(left, right);
        }

        #endregion

        public override string ToString()
        {
            return $"{nameof(Currency)}: {Currency}, {nameof(Amount)}: {Amount}";
        }
    }
}