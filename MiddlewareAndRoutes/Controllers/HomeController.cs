using Microsoft.AspNetCore.Mvc;
using MiddlewareAndRoutes.Models;
using System.Diagnostics;

namespace MiddlewareAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        public IActionResult Index() => View("Result",new Result
        {
            Controller = nameof(HomeController),
            Action = nameof(Index)
        });

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
