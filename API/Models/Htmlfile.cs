using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Htmlfile
{
    public int? TextLawId { get; set; }

    public string? TextName { get; set; }

    public string? TextHtml { get; set; }

    public int TextId { get; set; }

    public int? CustId { get; set; }
}
