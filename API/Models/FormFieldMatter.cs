using System;
using System.Collections.Generic;

namespace API.Models;

public partial class FormFieldMatter
{
    public int Id { get; set; }

    public int MatterId { get; set; }

    public int FormFieldId { get; set; }
}
