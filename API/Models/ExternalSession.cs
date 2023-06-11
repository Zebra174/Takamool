using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ExternalSession
{
    public int Id { get; set; }

    public int UserPid { get; set; }

    public string AppName { get; set; } = null!;

    public int MachineId { get; set; }

    public DateTime UtcCreated { get; set; }

    public DateTime UtcExpires { get; set; }

    public int Timeout { get; set; }
}
