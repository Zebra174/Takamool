using System;
using System.Collections.Generic;

namespace API.Models;

public partial class IsuuesRecord
{
    public long RecordId { get; set; }

    public string? IsuueNumber { get; set; }

    public int? EmpId { get; set; }

    public string? RecordEmp { get; set; }

    public DateTime? RecordDate { get; set; }
}
