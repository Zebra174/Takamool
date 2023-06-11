using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Expense
{
    public int Id { get; set; }

    public DateTime Incurred { get; set; }

    public DateTime? Paid { get; set; }

    public string Vendor { get; set; } = null!;

    public decimal Amount { get; set; }

    public string Details { get; set; } = null!;

    public virtual ICollection<ExpenseMatter> ExpenseMatters { get; set; } = new List<ExpenseMatter>();
}
