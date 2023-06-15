using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Consulting
{
    public int ConsuultingId { get; set; }

    public string ConstSubject { get; set; } = null!;

    public int? ConstType { get; set; }

    public int? CustomerId { get; set; }

    public string? Result { get; set; }
}
