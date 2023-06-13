using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TaskTemplate
{
    public int Id { get; set; }

    public string TaskTemplateTitle { get; set; } = null!;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool Active { get; set; }

    public string? ProjectedStart { get; set; }

    public string? DueDate { get; set; }

    public string? ActualEnd { get; set; }

    public string? ProjectedEnd { get; set; }
}
