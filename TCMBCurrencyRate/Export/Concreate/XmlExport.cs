using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TCMBCurrencyRate.Model;

namespace TCMBCurrencyRate.Export
{
    public class XmlExport : IExport
    {
        public string Export(List<Currency> currencies)
        {
            TextWriter writer = new StringWriter();
            XmlSerializer s = new XmlSerializer(currencies.GetType());
            s.Serialize(writer, currencies);
            return writer.ToString();
        }
    }
}
