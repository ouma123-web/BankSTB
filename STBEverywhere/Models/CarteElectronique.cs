using System;
using System.Collections.Generic;

namespace STBEverywhere.Models;

public partial class CarteElectronique
{
    public int CarteId { get; set; }

    public virtual Carte Carte { get; set; } = null!;
}
