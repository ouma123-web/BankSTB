using System;
using System.Collections.Generic;

namespace STBEverywhere.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Carte> Cartes { get; set; } = new List<Carte>();

    public virtual IEnumerable<Compte> Comptes { get; set; } = new List<Compte>();
}
