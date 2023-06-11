using System;
using System.Collections.Generic;

namespace API.Models;

public partial class IsuuesDatum
{
    public long? Id { get; set; }

    public string? IsuueNumber { get; set; }

    public string? CoureName { get; set; }

    public string? AssessorName { get; set; }

    public int? Lawer1 { get; set; }

    public int? Lawer2 { get; set; }

    public int? Lawer3 { get; set; }
}
