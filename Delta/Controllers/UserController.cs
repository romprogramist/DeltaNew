using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
}