using EventForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventForm.Controllers;

public class EventController(ILogger<EventController> logger) : Controller
{
    private readonly ILogger<EventController> _logger = logger;

    public IActionResult Index()
    {
        int hour = DateTime.Now.Hour;
        ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
        return View();
    }

    public IActionResult Privacy() => View();

    public IActionResult FilledForm() => View();

    [HttpPost]
    public IActionResult FilledForm(GuestResponse guestResponse)
    {
        Repository.AddResponse(guestResponse);
        return View("Thanks", guestResponse);
    }

    public IActionResult Thanks() => View();

    public IActionResult ListRespons() => View(Repository.Responses.Where(r => r.WillAttend == true));

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
