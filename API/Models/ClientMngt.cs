using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ClientMngt
{
    public long CmId { get; set; }

    public long? EocId { get; set; }

    public DateTime? FirstDateOfEpisode { get; set; }

    public DateTime? FirstDateOfContact { get; set; }

    public string? Discipline { get; set; }

    public int? WorkerNumber { get; set; }

    public string? CaseManager { get; set; }

    public string? WhyReferred { get; set; }

    public DateTime? DischargeDate { get; set; }

    public string? ClientStatus { get; set; }

    public string? Research1 { get; set; }

    public string? Research2 { get; set; }

    public string? Research3 { get; set; }

    public string? Facility { get; set; }

    public string? PhaseCare { get; set; }

    public string? FundSource { get; set; }

    public string? Operation { get; set; }

    public decimal? OperationCost { get; set; }
}
