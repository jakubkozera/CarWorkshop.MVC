using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.MVC.Models;

namespace CarWorkshop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult NoAccess()
    {
        return View();
    }

    public IActionResult About()
    {
        var model = new About()
        {
            Title = "CarWorkshop application",
            Description = "Some description",
            Tags = new List<string>() { "car", "app", "free" }
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        var model = new List<Person>()
        {
            new Person()
            {
                FirstName = "Jakub",
                LastName = "Kozera"
            },
            new Person()
            {
                FirstName = "Adam",
                LastName = "Małysz"
            },

        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
