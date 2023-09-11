using System;
using System.Collections.Generic;

namespace Delta.Data;

public partial class User
{
    public string UserName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}
