using System;
using System.Collections.Generic;

namespace Agap2IT.Academy.SuperMarket.Data.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
