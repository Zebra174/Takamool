using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public int? UserType { get; set; }

    public int? Age { get; set; }

    public string? Username { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Pass { get; set; }
}
