using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int BillToContactId { get; set; }

    public DateTime Date { get; set; }

    public DateTime Due { get; set; }

    public decimal Subtotal { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<InvoiceFee> InvoiceFees { get; set; } = new List<InvoiceFee>();
}
