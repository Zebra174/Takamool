using System;
using System.Collections.Generic;

namespace API.Models;

public partial class FeeMatter
{
    public int Id { get; set; }

    public int MatterId { get; set; }

    public int FeeId { get; set; }
}
