using System;
using System.Collections.Generic;

namespace API.Models;

public partial class BillingRate
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal PricePerUnit { get; set; }
}
