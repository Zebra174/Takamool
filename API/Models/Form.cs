using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Form
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int MatterTypeId { get; set; }

    public string Path { get; set; } = null!;
}
