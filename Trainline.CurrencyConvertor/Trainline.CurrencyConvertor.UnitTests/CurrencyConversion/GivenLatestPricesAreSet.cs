using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Trainline.CurrencyConvertor.Domain;
using Trainline.CurrencyConvertor.Services;
using Trainline.CurrencyConvertor.UnitTests.TestBed;

namespace Trainline.CurrencyConvertor.UnitTests.CurrencyConversion
{
    public class GivenLatestPricesAreSet
    {
        private const decimal GbpExchangeRate = 1m;
        private const decimal EurExchangeRate = 1.168852m;
        private const decimal UsdExchangeRate = 1.384935m;

        private CurrencyConversionService _conversionService;

        [SetUp]
        public void Setup()
        {
            IServiceProvider testBed = new TestBedBuilder()
                                      .WithExchangeProvider(new ExchangeRateProviderMock(new List<Price>
                                       {
                                           new Price(Currency.GBP, GbpExchangeRate),
                                           new Price(Currency.EUR, EurExchangeRate),
                                           new Price(Currency.USD, UsdExchangeRate)
                                       }))
                                      .Build();
            _conversionService = testBed.GetService<CurrencyConversionService>();
        }

        // TODO - better implemented with test case source...
        [TestCase("GBP", 1)]
        [TestCase("GBP", 0)]
        [TestCase("GBP", 1.1543874)]
        [TestCase("GBP", -1.1874)]
        public async Task WhenTheSourceAndTargetCurrencyMatch_ThenTheReturnedPriceShouldBeTheInputPrice(
            string currency, decimal value)
        {
            Price expectedPrice = new Price(new Currency(currency), value);
            Price actualPrice = await _conversionService.ConvertPrice(expectedPrice, new Currency(currency));

            Assert.AreEqual(expectedPrice, actualPrice, "Currency should not be converted but has changed.");
        }


        // TODO - better implemented with test case source...
        [TestCase("GBP", (double) GbpExchangeRate)]
        [TestCase("EUR", (double) EurExchangeRate)]
        [TestCase("USD", (double) UsdExchangeRate)]
        public async Task WhenTheSourceValueIs1_ThenTheReturnedPriceShouldMatchTheExchangeRate(
            string currency, decimal expectedAmount)
        {
            Price actualPrice =
                await _conversionService.ConvertPrice(new Price(new Currency("GBP"), 1), new Currency(currency));

            Assert.AreEqual(new Currency(currency), actualPrice.Currency,
                            "The incorrect currency was returned from the service.");
            Assert.AreEqual(expectedAmount, actualPrice.Amount, "The incorrect amount was returned");
        }

        [Ignore("Not implemented")]
        [TestCase("GBP")]
        [TestCase("EUR")]
        [TestCase("USD")]
        public void WhenTheRequestForExchangeRateIsMade_ThenTheCorrectCurrencyShouldBeRequested(string currency)
        {
            throw new NotImplementedException("Test method is called correctly using mocking framework such as MOQ.");
        }
    }
}