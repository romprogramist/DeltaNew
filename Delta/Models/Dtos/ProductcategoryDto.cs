namespace Delta.Models.Dtos;

public class ProductcategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public int? ParentCategoryId { get; set; } = null;
    public string? ParentCategoryName { get; set; }
}