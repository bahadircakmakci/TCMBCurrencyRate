using System;
using System.Collections.Generic;
using System.Text;
using TCMBCurrencyRate.Model;

namespace TCMBCurrencyRate.Export
{
    public class CsvExport : IExport
    {
        public string Export(List<Currency> currencies)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Unit;CurrencyCode;Isim;CurrencyName;ForexBuying;ForexSelling;BanknoteBuying;BanknoteSelling");
            
            foreach (var item in currencies)
            {
                sb.AppendLine($"{item.Unit};{item.CurrencyCode};{item.Isim};{item.CurrencyName};{item.ForexBuying};{item.ForexSelling};{item.BanknoteBuying};{item.BanknoteSelling}");
            }

            return sb.ToString();
        }
    }
}
