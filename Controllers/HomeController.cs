using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using foglietta.alice._5i.FORM_dotnetMVC.Models;

namespace foglietta.alice._5i.FORM_dotnetMVC.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }

    //[HttpGet]
    //public IActionResult Conferma()
    //{
        //return View();
    //}

    [HttpPost]
    public ActionResult Conferma(Prenotazione p)
    {
        return View(p);
    }

    [HttpGet]
    public IActionResult Prenota()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}