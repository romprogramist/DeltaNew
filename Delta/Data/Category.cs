namespace Delta.Data;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public int ParentCategoryId { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}