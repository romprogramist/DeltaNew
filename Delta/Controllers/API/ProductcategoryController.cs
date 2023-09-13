using Delta.Models;
using Delta.Models.Dtos;
using Delta.Services.ProductcategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers.API;


[ApiController]
[Route("api/productcategory")]
public class ProductcategoryController : ControllerBase
{
    private readonly IProductcategoryService _productcategoryService;

    public ProductcategoryController(IProductcategoryService productcategoryService)
    {
        _productcategoryService = productcategoryService;
    }
    
    
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetProductcategorys()
    {
        var productcategorys = await _productcategoryService.GetProductcategorysAsync();
        return Ok(productcategorys);
    }
    
    
    [HttpPost]
    [Route("add")]
    // [Authorize(Roles = "Admin")]  
    public async Task<IActionResult> AddProductcategory([FromForm] ProductcategoryModel productcategory)
    {
        var requestFiles = Request.Form.Files;
        if (requestFiles.Count > 0)
        {
            // if (requestFiles[0].Length > 1024 * 1024)
            // {
            //     return BadRequest("File size is too large.");
            // }
            productcategory.Image = await _productcategoryService.SaveProductcategoryImageAsync(requestFiles[0]);
        }
        
        var productcategoryDto = new ProductcategoryDto
        {
            Name = productcategory.Name,
            Image = productcategory.Image,
            Url = productcategory.Url,
            ParentCategoryId = productcategory.ParentCategoryId
        };
        
        var saved = await _productcategoryService.AddProductcategoryAsync(productcategoryDto);
        if(!saved)
            return BadRequest();
        return Ok();
    }
    
    [HttpPost]
    [Route("update")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateProductcategory([FromForm] ProductcategoryModel productcategory)
    {
        var requestFiles = Request.Form.Files;
        if (requestFiles.Count > 0)
        {
            productcategory.Image = await _productcategoryService.SaveProductcategoryImageAsync(requestFiles[0]);
        }
        else
        {
            productcategory.Image = string.Empty;
        }
        
        var productcategoryDto = new ProductcategoryDto
        {
            Id = productcategory.Id,
            Name = productcategory.Name,
            Image = productcategory.Image,
            Url = productcategory.Url,
            ParentCategoryId = productcategory.ParentCategoryId
        };
        
        var savedProductcategory = await _productcategoryService.UpdateProductcategoryAsync(productcategoryDto);
        if(savedProductcategory == null)
            return BadRequest();
        
        var productcategoryModel = new ProductcategoryModel
        {
            Id = savedProductcategory.Id,
            Name = savedProductcategory.Name,
            Image = savedProductcategory.Image,
            Url = savedProductcategory.Url,
            ParentCategoryId = savedProductcategory.ParentCategoryId
        };
        
        return Ok(productcategoryModel);
    }
    
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteProductCategory(int id)
    {
        var deleted = await _productcategoryService.DeleteProductCategoryAsync(id);
        if(!deleted)
            return BadRequest();
        return Ok();
    }
    
    
}