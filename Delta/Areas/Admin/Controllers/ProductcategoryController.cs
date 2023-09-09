using Delta.Models;
using Delta.Services.ProductcategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Areas.Admin.Controllers;

public class ProductcategoryController : BaseAdminController
{
    private readonly IProductcategoryService _productcategoryService;

    public ProductcategoryController(IProductcategoryService productcategoryService)
    {
        _productcategoryService = productcategoryService;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Add()
    {
        return View();
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var productcategory = await _productcategoryService.GetProductcategoryAsync(id);
        
        if(productcategory == null)
            return NotFound("reagentcategory not found.");
        
        var productcategoryModel = new ProductcategoryModel
        {
            Id = productcategory.Id,
            Name = productcategory.Name,
            Image = productcategory.Image,
            Url = productcategory.Url,
            ParentCategoryId = productcategory.ParentCategoryId,
            ParentCategoryName = productcategory.ParentCategoryName
        };
        return View(productcategoryModel);
    }
}