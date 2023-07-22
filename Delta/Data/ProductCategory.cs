using System;
using System.Collections.Generic;

namespace Delta.Data;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int ParentCategoryId { get; set; }

    public virtual ICollection<ProductCategory> InverseParentCategory { get; } = new List<ProductCategory>();

    public virtual ProductCategory ParentCategory { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
