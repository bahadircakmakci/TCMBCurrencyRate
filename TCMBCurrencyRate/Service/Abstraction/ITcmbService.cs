using System.Collections.Generic;
using TCMBCurrencyRate.Model;

namespace TCMBCurrencyRate.Service.Abstraction
{
    public interface ITcmbService
    {
        List<Currency> GetAllTCMBCurrencyRate();
    }
}
