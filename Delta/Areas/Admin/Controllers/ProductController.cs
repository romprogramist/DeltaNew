﻿using Microsoft.AspNetCore.Mvc;

namespace Delta.Areas.Admin.Controllers;

public class ProductController : BaseAdminController
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Add()
    {
        return View();
    }
    
    public IActionResult Edit()
    {
        return View();
    }
}