using System;
using System.Collections.Generic;

namespace STBEverywhere.Models;

public partial class CompteCourant
{
    public int CompteId { get; set; }

    public int AuthorisationDecouvert { get; set; }

    public virtual Compte Compte { get; set; } = null!;
}
