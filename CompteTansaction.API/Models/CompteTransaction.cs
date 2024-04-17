using System;
using System.Collections.Generic;

namespace CompteTansaction.API.Models;

public partial class CompteTransaction
{
    public int TransactionId { get; set; }

    public int CompteId { get; set; }
}
