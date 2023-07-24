using Microsoft.AspNetCore.Mvc;

namespace Delta.Areas.Admin.Controllers;

public class ReviewController : BaseAdminController
{
    public IActionResult Index()
    {
        return View();
    }
}