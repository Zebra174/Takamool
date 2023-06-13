using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class Isuue
{
    [Key]
    public long IsuueId { get; set; }

    public long? CustomerId { get; set; }

    public int? IsuueType { get; set; }

    public int? IsuueStatus { get; set; }

    public string? IsuueSubject { get; set; }

    public int? CustomerType { get; set; }

    public DateTime? IsuueOpenDate { get; set; }

    public string? IsuueSummary { get; set; }

    public string? IsuueDetail { get; set; }

    public string? ContractNumber { get; set; }

    public int? ContractType { get; set; }

    public string? LowerName { get; set; }

    public string? Isuuenumber { get; set; }

    public string? AgnName { get; set; }

    public string? Agnphone { get; set; }

    public string? Agnaddress { get; set; }

    public string? IsseName { get; set; }

    public string? CourtCity { get; set; }

    public string? CourtCircle { get; set; }
}
