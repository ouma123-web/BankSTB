using System;
using System.Collections.Generic;

namespace STBEverywhere.Models;

public partial class CarteVisaPremier
{
    public int CarteId { get; set; }

    public virtual Carte Carte { get; set; } = null!;
}
