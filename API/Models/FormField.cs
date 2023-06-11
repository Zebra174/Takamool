using System;
using System.Collections.Generic;

namespace API.Models;

public partial class FormField
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
