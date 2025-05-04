using Microsoft.AspNetCore.Mvc;
using MiddlewareAndRoutes.Models;

namespace MiddlewareAndRoutes.Controllers;

public class CustumerController : Controller
{
    public IActionResult Index() => View("Result", new Result
    {
        Controller = nameof(CustumerController),
        Action = nameof(Index)
    });

    public IActionResult About() => View("Result", new Result
    {
        Controller = nameof(CustumerController),
        Action = nameof(About)
    });
}
