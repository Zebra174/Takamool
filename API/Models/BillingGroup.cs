using System;
using System.Collections.Generic;

namespace API.Models;

public partial class BillingGroup
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? LastRun { get; set; }

    public DateTime? NextRun { get; set; }

    public decimal Amount { get; set; }

    public int BillToContactId { get; set; }
}
