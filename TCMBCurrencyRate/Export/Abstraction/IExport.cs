using System;
using System.Collections.Generic;
using System.Text;
using TCMBCurrencyRate.Model;

namespace TCMBCurrencyRate.Export
{
    public interface IExport
    {
        string Export(List<Currency> currencies);
    }
}
