using TCMBCurrencyRate.Enum;

namespace TCMBCurrencyRate.Export
{
    public static class Exporter
    {
        public static IExport GetExporter(Format format)
        {
            return format switch
            {
                Format.XML => new XmlExport(),
                Format.JSON => new JsonExport(),
                Format.CSV => new CsvExport(),
                _ => null,
            };
        }
    }
}
