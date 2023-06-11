using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Name
{
    public long NameId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Address { get; set; }

    public string? Suburb { get; set; }

    public string? HomePhone { get; set; }

    public string? ContactPhoneNumber { get; set; }

    public string? Sex { get; set; }

    public int? Language { get; set; }

    public bool? InterpretorNeeded { get; set; }

    public long? WorkerId { get; set; }

    public long? WorkerTypeId { get; set; }

    public string? WorkerType { get; set; }
}
