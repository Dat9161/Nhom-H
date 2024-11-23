using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class KhoHang
{
    public string CategoryId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
