using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TCMBCurrencyRate;
using TCMBCurrencyRate.Enum;
using TCMBCurrencyRate.Model;
using TCMBCurrencyRate.Service.Abstraction;
using Xunit;

namespace TBMBCurrencyRate.Tests
{
    public class GetCurrencyRateTests
    {
        [Fact]
        public void GetFiltredCurrencyRate_GivenAllParametersDefault_ReturnsOneCurrency()
        {
            // Arrange
            var tcmbService = new Mock<ITcmbService>();
            var returnObject = new List<Currency>
            {
                new Currency
                {
                    Isim = "AMERÝKAN DOLARI",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "USD",
                    CurrencyName = "AMERÝKAN DOLARI",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                }
            };

            tcmbService.Setup(x => x.GetAllTCMBCurrencyRate()).Returns(returnObject);
            var currencyService = new CurrencyService(tcmbService.Object);

            // Act
            var result = currencyService.GetFiltredCurrencyRate();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("AMERÝKAN DOLARI", result.First().Isim);
        }

        [Fact]
        public void GetFiltredCurrencyRate_GivenExpressionParameter_ReturnsNoCurrency()
        {
            // Arrange
            var tcmbService = new Mock<ITcmbService>();
            var returnObject = new List<Currency>
            {
                new Currency
                {
                    Isim = "AMERÝKAN DOLARI",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "USD",
                    CurrencyName = "AMERÝKAN DOLARI",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                }
            };

            tcmbService.Setup(x => x.GetAllTCMBCurrencyRate()).Returns(returnObject);
            var currencyService = new CurrencyService(tcmbService.Object);

            // Act
            var result = currencyService.GetFiltredCurrencyRate(x => x.Isim == "ÝNGÝLÝZ STERLÝNÝ");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetFiltredCurrencyRate_GivenExpressionParameter_ReturnsOneCurrency()
        {
            // Arrange
            var tcmbService = new Mock<ITcmbService>();
            var returnObject = new List<Currency>
            {
                new Currency
                {
                    Isim = "AMERÝKAN DOLARI",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "USD",
                    CurrencyName = "AMERÝKAN DOLARI",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                }
            };

            tcmbService.Setup(x => x.GetAllTCMBCurrencyRate()).Returns(returnObject);
            var currencyService = new CurrencyService(tcmbService.Object);

            // Act
            var result = currencyService.GetFiltredCurrencyRate(x => x.Isim == "AMERÝKAN DOLARI" && x.CurrencyCode == "USD");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("AMERÝKAN DOLARI", result.First().Isim);
        }

        [Fact]
        public void GetFiltredCurrencyRate_GivenOrderTableParameter_ReturnsAscendingOrderedCurrency()
        {
            // Arrange
            var tcmbService = new Mock<ITcmbService>();
            var returnObject = new List<Currency>
            {
                new Currency
                {
                    Isim = "AMERÝKAN DOLARI",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "USD",
                    CurrencyName = "AMERÝKAN DOLARI",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                },
                new Currency
                {
                    Isim = "ÝNGÝLÝZ STERLÝNÝ",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "GBP",
                    CurrencyName = "ÝNGÝLÝZ STERLÝNÝ",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                }
            };

            tcmbService.Setup(x => x.GetAllTCMBCurrencyRate()).Returns(returnObject);
            var currencyService = new CurrencyService(tcmbService.Object);

            // Act
            var result = currencyService.GetFiltredCurrencyRate(null, "Isim");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("AMERÝKAN DOLARI", result.First().Isim);
        }

        [Fact]
        public void GetFiltredCurrencyRate_GivenOrderTableParameter_ReturnsDescendingOrderedCurrency()
        {
            // Arrange
            var tcmbService = new Mock<ITcmbService>();
            var returnObject = new List<Currency>
            {
                new Currency
                {
                    Isim = "AMERÝKAN DOLARI",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "USD",
                    CurrencyName = "AMERÝKAN DOLARI",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                },
                new Currency
                {
                    Isim = "ÝNGÝLÝZ STERLÝNÝ",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "GBP",
                    CurrencyName = "ÝNGÝLÝZ STERLÝNÝ",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                }
            };

            tcmbService.Setup(x => x.GetAllTCMBCurrencyRate()).Returns(returnObject);
            var currencyService = new CurrencyService(tcmbService.Object);

            // Act
            var result = currencyService.GetFiltredCurrencyRate(null, "Isim", Sorting.DESC);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("ÝNGÝLÝZ STERLÝNÝ", result.First().Isim);
        }

        [Fact]
        public void Save_GivenInvalidFormat_ThrowsExceptions()
        {
            // Arrange
            var tcmbService = new Mock<ITcmbService>();
            var returnObject = new List<Currency>
            {
                new Currency
                {
                    Isim = "AMERÝKAN DOLARI",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "USD",
                    CurrencyName = "AMERÝKAN DOLARI",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                },
                new Currency
                {
                    Isim = "ÝNGÝLÝZ STERLÝNÝ",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "GBP",
                    CurrencyName = "ÝNGÝLÝZ STERLÝNÝ",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                }
            };

            tcmbService.Setup(x => x.GetAllTCMBCurrencyRate()).Returns(returnObject);
            var currencyService = new CurrencyService(tcmbService.Object);

            // Assert
            Assert.Throws<InvalidOperationException>(() => currencyService.Save(returnObject, Format.None));
        }

        [Fact]
        public void Save_GivenJsonFormat_ReturnsSerializedObject()
        {
            // Arrange
            var tcmbService = new Mock<ITcmbService>();
            var returnObject = new List<Currency>
            {
                new Currency
                {
                    Isim = "AMERÝKAN DOLARI",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "USD",
                    CurrencyName = "AMERÝKAN DOLARI",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                },
                new Currency
                {
                    Isim = "ÝNGÝLÝZ STERLÝNÝ",
                    Unit = 1,
                    BanknoteBuying = 5.22m,
                    BanknoteSelling = 5.21m,
                    CurrencyCode = "GBP",
                    CurrencyName = "ÝNGÝLÝZ STERLÝNÝ",
                    ForexBuying = 5.22m,
                    ForexSelling = 5.21m
                }
            };

            tcmbService.Setup(x => x.GetAllTCMBCurrencyRate()).Returns(returnObject);
            var currencyService = new CurrencyService(tcmbService.Object);

            // Act
            var result = currencyService.Save(returnObject, Format.JSON);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains("GBP", result); 
            Assert.Contains("USD", result);
        }
    }
}
