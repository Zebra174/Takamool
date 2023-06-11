using System;
using System.Collections.Generic;

namespace API.Models;

public partial class NoteNotification
{
    public int Id { get; set; }

    public int ContactId { get; set; }

    public int NoteId { get; set; }
}
