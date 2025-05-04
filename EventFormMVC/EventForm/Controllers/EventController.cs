using EventForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static EventForm.Models.Repository;
using EventForm.EventFormData;
using Microsoft.EntityFrameworkCore;
namespace EventForm.Controllers;

public class EventController(EventFormContext context) : Controller
{
    //private readonly ILogger<EventController> _logger;

    //public EventController(ILogger<EventController> logger) => _logger = logger;

    private readonly EventFormContext _context = context;

    public Task<IActionResult> Index()
    {
        int hour = DateTime.Now.Hour;
        ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
        return Task.FromResult<IActionResult>(View());
    }

    public Task<IActionResult> Privacy() => Task.FromResult<IActionResult>(View());

    public Task<IActionResult> FilledForm() => Task.FromResult<IActionResult>(View());

    [HttpPost]
    public Task<IActionResult> FilledForm(GuestResponse guestResponse)
    {
        //AddResponse(guestResponse);
        _context.GuestResponses.Update(guestResponse);
        _context.SaveChanges();
        return Task.FromResult<IActionResult>(View("Thanks", guestResponse));
    }

    public Task<IActionResult> Thanks() => Task.FromResult<IActionResult>(View());

    public Task<IActionResult> ListRespons() => Task.FromResult<IActionResult>(View(_context.GuestResponses.Where(r => r.WillAttend == true)));

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public Task<IActionResult> Error() => Task.FromResult<IActionResult>(View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }));
}
