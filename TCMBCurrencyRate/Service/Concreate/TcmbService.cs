using System.Collections.Generic;
using System.Xml.Linq;
using TCMBCurrencyRate.Model;
using TCMBCurrencyRate.Service.Abstraction;

namespace TCMBCurrencyRate.Service.Concreate
{
    public class TcmbService : ITcmbService
    {
        public List<Currency> GetAllTCMBCurrencyRate()
        {
            var XDoc = XDocument.Load(@"https://www.tcmb.gov.tr/kurlar/today.xml");

            var rootElement = XDoc.Root;
            var elementler = new List<Currency>();

            foreach (XElement item in rootElement.Elements())
            {
                elementler.Add(new Currency
                {
                    CurrencyCode = item.Attribute("CurrencyCode").Value.Trim(),
                    Unit = int.Parse(item.Element("Unit").Value.Trim()),
                    Isim = item.Element("Isim").Value.Trim(),
                    CurrencyName = item.Element("CurrencyName").Value.Trim(),
                    BanknoteBuying = GetPrice(item.Element("BanknoteBuying").Value),
                    BanknoteSelling = GetPrice(item.Element("BanknoteSelling").Value),
                    ForexBuying = GetPrice(item.Element("ForexBuying").Value),
                    ForexSelling = GetPrice(item.Element("ForexSelling").Value)
                });
            }

            return elementler;
        }

        private decimal GetPrice(string sourcePrice)
        {
            if (!string.IsNullOrEmpty(sourcePrice))
            {
                if (decimal.TryParse(sourcePrice.Trim().Replace(".", ","), out var price))
                    return price;
            }

            return 0;
        }
    }
}
