using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class Customer
{
    public string CustName { get; set; } = null!;

    public string? CustAddress { get; set; }

    public string? CustCity { get; set; }

    public string? CustIdNumber { get; set; }

    public string? CustEmail { get; set; }

    public string? CustMobile { get; set; }

[Key]
    public int CustId { get; set; }
}
