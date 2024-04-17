using System;
using System.Collections.Generic;

namespace Carte.API.Models;

public partial class CarteElectronique
{
    public int CarteId { get; set; }

    public virtual Carte Carte { get; set; } = null!;
}
