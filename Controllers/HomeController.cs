using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEMA.Models;
using SEMA.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEMA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventAppService _eventAppService;

        public HomeController(ILogger<HomeController> logger, IEventAppService eventAppService)
        {
            _logger = logger;
            _eventAppService = eventAppService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _eventAppService.GetAllAsync();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CalenderEvents()
        {
           
            return View("CalenderEvents");
        }
        public async Task<IActionResult> GetEventsAsync()
        {
                var events =await _eventAppService.GetAllAsync();
                return new JsonResult(new {  Data = events }) ;
        }
        
    }
}
