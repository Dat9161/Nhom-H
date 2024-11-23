using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Customer
{
    public string IdUser { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly? Birthday { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
