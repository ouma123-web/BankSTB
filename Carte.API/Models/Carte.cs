
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carte.API.Models;

public partial class Carte
{
    public int CarteId { get; set; }

    public string NumCarte { get; set; } = null!;

    public decimal CodeSecretCarte { get; set; }

    public DateOnly DateExpiration { get; set; }

    public int? ClientId { get; set; }

    public virtual CarteElectronique? CarteElectronique { get; set; }

    public virtual CarteVisaPremier? CarteVisaPremier { get; set; }

    [ForeignKey("ClientId")]
    public virtual Client? Client { get; set; }
}
