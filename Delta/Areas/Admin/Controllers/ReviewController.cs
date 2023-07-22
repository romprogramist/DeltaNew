using Microsoft.AspNetCore.Mvc;

namespace Delta.Areas.Admin.Controllers;

[Area("Admin")]
public class ReviewController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}