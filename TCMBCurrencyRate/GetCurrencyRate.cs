using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TCMBCurrencyRate.Enum;
using TCMBCurrencyRate.Model;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace TCMBCurrencyRate
{
    public static class GetCurrencyRate
    {

        private static List<Currency> GetAllTBMBCurrencyRate()
        {
            XDocument XDoc = XDocument.Load(@"https://www.tcmb.gov.tr/kurlar/today.xml");

            XElement rootElement = XDoc.Root;
            var elementler = new List<Currency>();

            foreach (XElement item in rootElement.Elements())
            {

                elementler.Add(new Currency
                {
                    CurrencyCode = item.Attribute("CurrencyCode").Value.Trim(),
                    Unit = int.Parse(item.Element("Unit").Value.Trim()),
                    Isim = item.Element("Isim").Value.Trim(),
                    CurrencyName = item.Element("CurrencyName").Value.Trim(),
                    BanknoteBuying = item.Element("BanknoteBuying").Value != "" ? decimal.Parse(item.Element("BanknoteBuying").Value.Trim().Replace(".", ",")) : 0,
                    BanknoteSelling = item.Element("BanknoteSelling").Value != "" ? decimal.Parse(item.Element("BanknoteSelling").Value.Trim().Replace(".", ",")) : 0,
                    ForexBuying = item.Element("ForexBuying").Value != "" ? decimal.Parse(item.Element("ForexBuying").Value.Trim().Replace(".", ",")) : 0,
                    ForexSelling = item.Element("ForexSelling").Value != "" ? decimal.Parse(item.Element("ForexSelling").Value.Trim().Replace(".", ",")) : 0


                });
            }

            return elementler;
        }

        public static List<Currency> GetFiltredCurrencyRate(string orderTable, Sorting sorting = Sorting.ASC)
        {
            var currencies = GetAllTBMBCurrencyRate();
           
            if (orderTable != null && orderTable!="")
            {
                var getproperty = typeof(Currency).GetProperty(orderTable);
                if (sorting == Sorting.ASC)
                {
                    return currencies.OrderBy(p => getproperty.GetValue(p)).ToList();
                }
                else
                {
                    return currencies.OrderByDescending(p => getproperty.GetValue(p)).ToList();
                }
            }
            else
            {
                return currencies;
            }



        }
        public static void Save(List<Currency> filterList,string savePath,string filename, Format format = Format.XML)
        {

            switch (format)
            {
                case Format.XML:
                    {
                        FileStream fsxml = new FileStream(Path.Combine(savePath,filename+".xml"), FileMode.OpenOrCreate);
                        XmlSerializer s = new XmlSerializer(filterList.GetType());
                        s.Serialize(fsxml, filterList);
                        fsxml.Close();
                        break;
                    }
                case Format.JSON:
                    FileStream fsjson = new FileStream(Path.Combine(savePath, filename+".json"), FileMode.OpenOrCreate);
                    StreamWriter sw = new StreamWriter(fsjson, Encoding.UTF8);                    
                    sw.Write(JsonSerializer.Serialize(filterList).ToString());
                    sw.Close();
                    fsjson.Close();
                    break;
                case Format.CSV:
                    FileStream fscvs = new FileStream(Path.Combine(savePath, filename+".csv"), FileMode.OpenOrCreate);
                    StreamWriter swcvs = new StreamWriter(fscvs,Encoding.UTF8);
                    swcvs.WriteLine("Unit;CurrencyCode;Isim;CurrencyName;ForexBuying;ForexSelling;BanknoteBuying;BanknoteSelling");
                    foreach (var item in filterList)
                    {
                        swcvs.WriteLine(item.Unit + ";"+item.CurrencyCode+";" + item.Isim + ";" + item.CurrencyName+";"+item.ForexBuying+";"+item.ForexSelling+";"+item.BanknoteBuying+";"+item.BanknoteSelling) ;
                    }
                    swcvs.Close();
                    fscvs.Close();
                    break;
                default:
                    break;
            }

             
        }



    }

}