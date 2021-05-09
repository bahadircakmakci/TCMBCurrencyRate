using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TCMBCurrencyRate.Model
{
    
    [Serializable]
    [XmlRoot("root")]
    public class Currency
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
        [XmlElement(ElementName = "Unit")]
        public int Unit { get; set; }
        [XmlElement(ElementName = "Isim")]
        public string Isim { get; set; }
        [XmlElement(ElementName = "CurrencyName")]
        public string CurrencyName { get; set; }
        [XmlElement(ElementName = "ForexBuying")]
        public decimal? ForexBuying { get; set; }
        [XmlElement(ElementName = "ForexSelling")]
        public decimal? ForexSelling { get; set; }
        [XmlElement(ElementName = "BanknoteBuying")]
        public decimal? BanknoteBuying { get; set; }
        [XmlElement(ElementName = "BanknoteSelling")]
        public decimal? BanknoteSelling { get; set; }
     
    }
}
