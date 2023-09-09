using Delta.Models;
using Delta.Models.Dtos;
using Delta.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers.API;


[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    
    
    
    [HttpPost]
    [Route("add")]
    // [Authorize(Roles = "Admin")]  
    public async Task<IActionResult> AddProduct([FromForm] ProductModel product)
    {
        // var requestFiles = Request.Form.Files;
        // if (requestFiles.Count > 0)
        // {
        //     if (requestFiles[0].Length > 1024 * 1024)
        //     {
        //         return BadRequest("File size is too large.");
        //     }
        //     reagent.InstructionPdf = await _reagentService.SaveReagentImageAsync(requestFiles[0]);
        // }
        
        var productDto = new ProductDto
        {
            Model = product.Model,
            Description = product.Description,
            TechInfo = product.TechInfo,
            Url = product.Url,
            ModelSeries = product.ModelSeries,
            Type = product.Type,
            CardTitle = product.CardTitle,
            LongNamePrefix = product.LongNamePrefix,
            CompanyId = product.CompanyId,
            // ProductCategoriesId = product.ProductCategoriesId
        };
        
        
        
        var saved = await _productService.AddProductAsync(productDto);
        if(!saved)
            return BadRequest();
        return Ok();
    }
    
}