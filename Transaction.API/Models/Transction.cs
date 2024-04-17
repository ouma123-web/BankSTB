using System;
using System.Collections.Generic;

namespace Transaction.API.Models;

public partial class Transction
{
    public int TransactionId { get; set; }

    public DateOnly DateOperation { get; set; }

    public DateOnly DateValeur { get; set; }

    public decimal Montant { get; set; }

    public string? Description { get; set; }

    public string? Autorisation { get; set; }

    public virtual ICollection<CompteTransaction> CompteTransactions { get; set; } = new List<CompteTransaction>();
}
