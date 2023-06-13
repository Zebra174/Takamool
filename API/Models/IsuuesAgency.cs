using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class IsuuesAgency
{
    [Key]
    public long AgenceId { get; set; }

    public DateTime? AgenceDate { get; set; }

    public string? AgenceName { get; set; }

    public string? AgenceNote { get; set; }

    public int? AgenceType { get; set; }

    public DateTime? AgenceFromDate { get; set; }

    public DateTime? AgenceTo { get; set; }

    public string? AgencePic { get; set; }

    public string? IsuueNumber { get; set; }

    public long? AgenceNo { get; set; }
}
