using FractionCalculatorLibrary;
using FractionCalculatorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FractionCalculatorWeb.Controllers;

public class CalculatorController : Controller
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger) => _logger = logger;

    public IActionResult Index()
    {
        ViewBag.Answer = "0";
        return View();
    }

    [HttpPost]
    public ActionResult Calculate(string num1, string den1, string num2, string den2, string op)
    {
        if (int.TryParse(num1, out int intNum1) && int.TryParse(den1, out int intDen1) &&
            int.TryParse(num2, out int intNum2) && int.TryParse(den2, out int intDen2))
        {
            Fraction fraction1 = new(intNum1, intDen1);
            Fraction fraction2 = new(intNum2, intDen2);
            Fraction result = new();

            switch (op)
            {
                case "+":
                    result = fraction1 + fraction2;
                    break;
                case "-":
                    result = fraction1 - fraction2;
                    break;
                case "*":
                    result = fraction1 * fraction2;
                    break;
                case "/":
                    result = fraction1 / fraction2;
                    break;
            }
            ViewBag.Answer = result.ToString() ?? "Error";
        }
        else
        {
            ViewBag.Answer = "Please enter valid numbers.";
        }

        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}