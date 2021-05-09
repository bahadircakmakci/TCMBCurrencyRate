using System.Collections.Generic;
using System.Linq;
using TCMBCurrencyRate.Enum;
using TCMBCurrencyRate.Model;
using System;
using TCMBCurrencyRate.Export;
using TCMBCurrencyRate.Service.Abstraction;

namespace TCMBCurrencyRate
{
    public class CurrencyService : ICurrencyService
    {
        public List<Currency> Currencies { get; private set; }

        public CurrencyService(ITcmbService tcmbService)
        {
            Currencies = tcmbService.GetAllTCMBCurrencyRate();
        }

        public List<Currency> GetFiltredCurrencyRate(Func<Currency, bool> expression = null, string orderTable = null, Sorting sorting = Sorting.ASC)
        {
            var currencies = Currencies;

            if (expression != null)
            {
                currencies = currencies.Where(expression).ToList();
            }

            if (!string.IsNullOrEmpty(orderTable))
            {
                var getproperty = typeof(Currency).GetProperty(orderTable);
                if (sorting == Sorting.ASC)
                {
                    currencies = currencies.OrderBy(p => getproperty.GetValue(p)).ToList();
                }
                else
                {
                    currencies = currencies.OrderByDescending(p => getproperty.GetValue(p)).ToList();
                }
            }

            return currencies.ToList();
        }

        public string Save(List<Currency> filterList, Format format = Format.XML)
        {
            var exporter = Exporter.GetExporter(format);

            if (exporter == null)
                throw new InvalidOperationException("Exporter not found.");

            return exporter.Export(filterList);
        }
    }
}