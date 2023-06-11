using System;
using System.Collections.Generic;

namespace API.Models;

public partial class InvoiceTime
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int TimeId { get; set; }

    public decimal PricePerUnit { get; set; }

    public decimal Quantity { get; set; }

    public string Details { get; set; } = null!;
}
