using System;
using System.Collections.Generic;

namespace STBEverywhere.Models;

public partial class CompteEpargne
{
    public int CompteId { get; set; }

    public decimal TauxDeRemuneration { get; set; }

    public virtual Compte Compte { get; set; } = null!;
}
