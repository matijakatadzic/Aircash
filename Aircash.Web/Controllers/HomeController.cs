using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aircash.Web.Models;
using Aircash.Web.Business.HttpClientService;

namespace Aircash.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IApiService _apiService;

        public HomeController(ILogger<HomeController> logger, IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Api()
        {
            var response = await _apiService.GetIataCodeAsync();
            return View(response.Value);
        }

        public async Task<IActionResult> _Api(string iataSelect, DateTime checkIn, DateTime checkOut, int adult, bool available)
        {
            var response = await _apiService.GetHotelsAndOffersAsync(iataSelect, checkIn, checkOut, adult, available);
            return PartialView(response);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
