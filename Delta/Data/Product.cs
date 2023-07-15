using System;
using System.Collections.Generic;

namespace Delta.Data;

public partial class Product
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

    public virtual Company Company { get; set; } = null!;

    public virtual ProductCategory ProductCategories { get; set; } = null!;

    public virtual ICollection<ProductImage> ProductImages { get; } = new List<ProductImage>();

    public virtual ICollection<Certificate> Certificates { get; } = new List<Certificate>();

    public virtual ICollection<Consumable> Consumables { get; } = new List<Consumable>();

    public virtual ICollection<Reagent> Reagents { get; } = new List<Reagent>();
}
