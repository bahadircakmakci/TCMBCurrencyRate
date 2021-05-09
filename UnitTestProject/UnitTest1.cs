using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TCMBCurrencyRate.Model;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCurrencyRateTest()
        {
          var sonuc=  TCMBCurrencyRate.GetCurrencyRate.GetFiltredCurrencyRate(null, null);

            CollectionAssert.AllItemsAreNotNull(sonuc);
        }
    }
}
