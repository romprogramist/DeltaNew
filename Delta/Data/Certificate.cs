using System;
using System.Collections.Generic;

namespace Delta.Data;

public partial class Certificate
{
    public int Id { get; set; }

    public string Image { get; set; } = null!;

    public string Pdf { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
