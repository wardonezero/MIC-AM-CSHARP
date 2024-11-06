using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;
using System.Diagnostics;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository repository;

        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        //public ViewResult Index(int id) => View(repository[id]);
        //public ViewResult Index(int id) => View(repository[id] ?? repository.People.First());

        public IActionResult Index(int? id)
        {
            Person person;
            if (id.HasValue && (person = repository[id.Value]) != null)
                return View(person);
            else
                return NotFound();
        }

        public ViewResult Create() => View(new Person());
        [HttpPost]
        public ViewResult Create(Person model) => View("index", model);

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
