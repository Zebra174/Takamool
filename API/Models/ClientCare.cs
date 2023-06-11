using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ClientCare
{
    public long EocId { get; set; }

    public long? IntakeId { get; set; }

    public long? SubIntakeNumber { get; set; }

    public long? NameId { get; set; }

    public DateTime FirstDateOfEpisode { get; set; }

    public string? CaseManager { get; set; }

    public string? ClientStatus { get; set; }

    public string? DependencyStatusBeginning { get; set; }

    public string? DependencyStatusEnd { get; set; }

    public string? NatureOfCare { get; set; }

    public DateTime? DischargeDate { get; set; }

    public string? ClientType { get; set; }

    public string? Caseload { get; set; }

    public string? OverallEocStatus { get; set; }

    public string? Facility { get; set; }

    public string? DisciplineIntake { get; set; }

    public decimal? OperationCost { get; set; }

    public string? Operation { get; set; }
}
