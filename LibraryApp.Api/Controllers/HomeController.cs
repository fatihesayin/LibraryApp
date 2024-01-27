using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
    }
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Book", new {CurrentPage = 0, PageSize = 10});
    }
}
