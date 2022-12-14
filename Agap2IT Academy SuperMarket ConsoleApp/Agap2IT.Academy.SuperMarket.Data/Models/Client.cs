using Agap2IT.Academy.SuperMarket.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Agap2IT.Academy.SuperMarket.Data.Models;

public partial class Client : IReferencedEntity
{
    public int Id { get; set; }

    public Guid Uuid { get; set; }

    public string Name { get; set; } = null!;

    public string Nif { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
}
