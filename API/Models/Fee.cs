using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Fee
{
    public int Id { get; set; }

    public DateTime Incurred { get; set; }

    public decimal Amount { get; set; }

    public string Details { get; set; } = null!;

    public virtual ICollection<InvoiceFee> InvoiceFees { get; set; } = new List<InvoiceFee>();
}
