using System;
using System.Collections.Generic;

namespace Delta.Data;

public partial class Reagent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CompanyId { get; set; }

    public string InstructionPdf { get; set; } = null!;

    public string? KitComposition { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<ReagentCategory> ReagentCategories { get; set; } = new List<ReagentCategory>();
}
