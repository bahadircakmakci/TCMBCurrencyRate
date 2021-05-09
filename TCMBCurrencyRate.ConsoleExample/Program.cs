using Microsoft.Extensions.DependencyInjection;
using System;
using TCMBCurrencyRate.Enum;
using TCMBCurrencyRate.Helpers;
using TCMBCurrencyRate.Service.Abstraction;

namespace TCMBCurrencyRate.ConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddCurrencyRate()
                .BuildServiceProvider();

            var currencyRate = serviceProvider.GetService<ICurrencyService>();
            var currencies = currencyRate.GetFiltredCurrencyRate();
            var output = currencyRate.Save(currencies, Format.XML);

            Console.WriteLine(output);
        }
    }
}
