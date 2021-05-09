using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TCMBCurrencyRate.Model;

namespace TCMBCurrencyRate.Export
{
    public class JsonExport : IExport
    {
        public string Export(List<Currency> currencies)
        {
            return JsonSerializer.Serialize(currencies);
        }
    }
}
