using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Order
{
  

    public string OrderId { get; set; } = null!;

    public string? IdUser { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual Customer? IdUserNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
