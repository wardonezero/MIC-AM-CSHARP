using Microsoft.AspNetCore.Mvc;
using MiddlewareAndRoutes.Models;

namespace MiddlewareAndRoutes.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index() => View("Result", new Result
        {
            Controller = nameof(AdminController),
            Action = nameof(Index)
        });

        public IActionResult About() => View("Result", new Result
        {
            Controller = nameof(AdminController),
            Action = nameof(About)
        });
    }
}