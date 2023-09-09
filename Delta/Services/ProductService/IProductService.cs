using Delta.Models.Dtos;

namespace Delta.Services.ProductService;

public interface IProductService
{
    Task<bool> AddProductAsync(ProductDto product);
}