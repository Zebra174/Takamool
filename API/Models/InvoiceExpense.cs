using System;
using System.Collections.Generic;

namespace API.Models;

public partial class InvoiceExpense
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int ExpenseId { get; set; }

    public decimal Amount { get; set; }

    public string Details { get; set; } = null!;
}
