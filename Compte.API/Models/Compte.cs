using STBEverywhere.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace Compte.API.Models;

public partial class Compte
{
    public int CompteId { get; set; }

    public string NumCompte { get; set; } = null!;

    public decimal Solde { get; set; }

    public DateOnly DateOuverture { get; set; }

    public int? ClientId { get; set; }

    [ForeignKey("ClientId")]
    public virtual Client? Client { get; set; }

    public virtual CompteCheque? CompteCheque { get; set; }

    public virtual CompteCourant? CompteCourant { get; set; }

    public virtual CompteEnDevise? CompteEnDevise { get; set; }

    public virtual CompteEpargne? CompteEpargne { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } //= new List<Transction>();
}
