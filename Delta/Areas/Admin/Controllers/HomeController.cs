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
    public IActionResult Reagentcategories()
    {
        return RedirectToAction("Index", "Reagentcategories");
    }
    public IActionResult Aboutus()
    {
        return RedirectToAction("Index", "Aboutus");
    }
    public IActionResult Contact()
    {
        return RedirectToAction("Index", "Contact");
    }
    public IActionResult Productcategory()
    {
        return RedirectToAction("Index", "Productcategory");
    }
    
}

