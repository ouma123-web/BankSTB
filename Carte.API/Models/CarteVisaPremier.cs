using System;
using System.Collections.Generic;

namespace Carte.API.Models;

public partial class CarteVisaPremier
{
    public int CarteId { get; set; }

    public virtual Carte Carte { get; set; } = null!;
}
