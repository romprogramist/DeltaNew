using Microsoft.AspNetCore.Mvc;

namespace Delta.Areas.Admin.Controllers;

public class HomeController : BaseAdminController
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Product");
    }
    
}
