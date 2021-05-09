using Microsoft.Extensions.DependencyInjection;
using TCMBCurrencyRate.Service.Abstraction;
using TCMBCurrencyRate.Service.Concreate;

namespace TCMBCurrencyRate.Helpers
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCurrencyRate(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITcmbService, TcmbService>();
            serviceCollection.AddScoped<ICurrencyService, CurrencyService>();

            return serviceCollection;
        }
    }
}
