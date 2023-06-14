using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool? Active { get; set; }

    public DateTime? ProjectedStart { get; set; }

    public DateTime? ProjectedEnd { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? ActualEnd { get; set; }

    public int? TaskStatus { get; set; }

    public string? EmpName { get; set; }

    public string? ProjManger { get; set; }

    public double? TaskProgress { get; set; }
}
