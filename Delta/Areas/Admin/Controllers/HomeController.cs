using Microsoft.AspNetCore.Mvc;

namespace Delta.Areas.Admin.Controllers;

public class HomeController : BaseAdminController
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Product");
    }
    
    public IActionResult Company()
    {
        return RedirectToAction("Index", "Company");
    }
    public IActionResult Reagent()
    {
        return RedirectToAction("Index", "Reagent");
    }
}
