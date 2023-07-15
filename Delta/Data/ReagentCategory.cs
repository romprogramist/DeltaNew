using System;
using System.Collections.Generic;

namespace Delta.Data;

public partial class ReagentCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Reagent> Reagents { get; } = new List<Reagent>();
}
