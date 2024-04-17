using System.ComponentModel.DataAnnotations;
using STBEverywhere.Models;

namespace Client.API.Models;

public partial class Client
{
    

    [Key]
    public int ClientId { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Carte> Cartes { get; set; } = new List<Carte>();

    public virtual ICollection<Compte> Comptes { get; set; } = new List<Compte>();
}
