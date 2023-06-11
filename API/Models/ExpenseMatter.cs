using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ExpenseMatter
{
    public int Id { get; set; }

    public int MatterId { get; set; }

    public int ExpenseId { get; set; }

    public virtual Expense Expense { get; set; } = null!;
}
