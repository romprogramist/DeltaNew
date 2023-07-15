using System;
using System.Collections.Generic;

namespace Delta.Data;

public partial class ClientApplication
{
    public int Id { get; set; }

    public DateTime CreationDateTime { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string SitePage { get; set; } = null!;

    public string AdditionalInfo { get; set; } = null!;

    public string UtmInfo { get; set; } = null!;
}
