using Microsoft.AspNetCore.Mvc;

namespace EMApi.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}