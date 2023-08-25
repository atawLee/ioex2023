using System;
using System.Collections.Generic;

namespace MarketApp.Server.Database.Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public int? UserId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public decimal Price { get; set; }

    public string? Content { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual User? User { get; set; }
}
