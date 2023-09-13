namespace Delta.Models.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Model { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string TechInfo { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string? ModelSeries { get; set; }
    public short Type { get; set; }
    public string CardTitle { get; set; } = null!;
    public string? LongNamePrefix { get; set; }
    public int CompanyId { get; set; }
    public int ProductCategoriesId { get; set; }
}