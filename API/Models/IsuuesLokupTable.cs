using System;
using System.Collections.Generic;

namespace API.Models;

public partial class IsuuesLokupTable
{
    public int LokupType { get; set; }

    public int LokupId { get; set; }

    public string? LokupValue { get; set; }
}
