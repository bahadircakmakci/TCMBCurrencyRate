using System;
using System.Collections.Generic;
using TCMBCurrencyRate.Enum;
using TCMBCurrencyRate.Model;

namespace TCMBCurrencyRate.Service.Abstraction
{
    public interface ICurrencyService
    {
        List<Currency> Currencies { get; }
        List<Currency> GetFiltredCurrencyRate(Func<Currency, bool> expression = null, string orderTable = null, Sorting sorting = Sorting.ASC);
        string Save(List<Currency> filterList, Format format = Format.XML);
    }
}
