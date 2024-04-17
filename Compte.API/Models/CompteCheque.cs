using System;
using System.Collections.Generic;

namespace Compte.API.Models;

public partial class CompteCheque
{
    public int CompteId { get; set; }

    public virtual Compte Compte { get; set; } = null!;
}
