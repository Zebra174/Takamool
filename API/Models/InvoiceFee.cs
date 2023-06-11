using System;
using System.Collections.Generic;

namespace API.Models;

public partial class InvoiceFee
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int FeeId { get; set; }

    public decimal Amount { get; set; }

    public decimal TaxAmount { get; set; }

    public string Details { get; set; } = null!;

    public virtual Fee Fee { get; set; } = null!;

    public virtual Invoice Invoice { get; set; } = null!;
}
