using System;
using System.Collections.Generic;

namespace STBEverywhere.Models;

public partial class CompteEnDevise
{
    public int CompteId { get; set; }

    public virtual Compte Compte { get; set; } = null!;
}
