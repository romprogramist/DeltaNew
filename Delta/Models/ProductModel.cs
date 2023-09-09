namespace Delta.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Model { get; set; }  = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string TechInfo { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string? ModelSeries { get; set; }

    public short Type { get; set; }
    public string CardTitle { get; set; } = string.Empty;
    public string? LongNamePrefix { get; set; }
    public int CompanyId { get; set; }
    public int ProductCategoriesId { get; set; }
}