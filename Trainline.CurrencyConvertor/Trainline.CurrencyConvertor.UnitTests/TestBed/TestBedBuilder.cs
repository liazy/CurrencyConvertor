using System;
using Microsoft.Extensions.DependencyInjection;
using Trainline.CurrencyConvertor.Services;

namespace Trainline.CurrencyConvertor.UnitTests.TestBed
{
    public class TestBedBuilder
    {
        private IExchangeRateProvider _exchangeRateProvider;

        public IServiceProvider Build()
        {
            var serviceContainer = new ServiceCollection();

            // TODO - Should mirror the transient behaviour of the main application...
            serviceContainer.AddSingleton(_exchangeRateProvider ?? new ExchangeRateProviderMock());

            serviceContainer.AddTransient<CurrencyConversionService>();

            return serviceContainer.BuildServiceProvider();
        }

        public TestBedBuilder WithExchangeProvider(IExchangeRateProvider exchangeRateProvider)
        {
            _exchangeRateProvider = exchangeRateProvider;
            return this;
        }
    }
}