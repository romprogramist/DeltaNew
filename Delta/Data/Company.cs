using System;
using System.Collections.Generic;

namespace Delta.Data;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<Reagent> Reagents { get; } = new List<Reagent>();
}
