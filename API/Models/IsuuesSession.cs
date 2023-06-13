using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class IsuuesSession
{
    [Key]
    public long SessionId { get; set; }

    public DateTime? SessionDate { get; set; }

    public string? SessionName { get; set; }

    public string? SessionNote { get; set; }

    public DateTime? SessionNextDate { get; set; }

    public string? SessionNextName { get; set; }

    public int? CustomerInv { get; set; }

    public int? AisuueNumber { get; set; }
}
