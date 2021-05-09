using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TCMBCurrencyRate.Enum;
using TCMBCurrencyRate.Service.Abstraction;
using TCMBCurrencyRate.WebExample.Models;

namespace TCMBCurrencyRate.WebExample.Controllers
{
    public class HomeController : Controller
    {
     
        private readonly ICurrencyService _currencyService; 
        public HomeController(ICurrencyService currencyService)
        {
            
            _currencyService = currencyService;
        }

        public IActionResult Index()
        {
            var result =_currencyService.GetFiltredCurrencyRate();

            ViewBag.Result = _currencyService.Save(result, Format.JSON);
            return View();
        }
 
    }
}
