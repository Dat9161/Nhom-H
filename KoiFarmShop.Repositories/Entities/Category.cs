using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Category
{
    public string CategoryId { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<KhoHang> KhoHangs { get; set; } = new List<KhoHang>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
