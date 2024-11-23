using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities
{
    public partial class Product
    {
        public string ProductId { get; set; } = null!;  // Mã sản phẩm

        public string ProductName { get; set; } = null!; // Tên sản phẩm

        public string? Brand { get; set; } // Thương hiệu sản phẩm

        public double? Weight { get; set; } // Trọng lượng sản phẩm

        public string? CategoryId { get; set; } // Mã danh mục sản phẩm

        public string? Description { get; set; } // Mô tả sản phẩm

        public string? ImageUrl { get; set; } // Đường dẫn hình ảnh sản phẩm
        public double Price { get; set; } // Giá sản phẩm
        public string Title { get; set; }

        public virtual Category? Category { get; set; } // Liên kết đến bảng Category

        public virtual ICollection<KhoHang> KhoHangs { get; set; } = new List<KhoHang>(); // Liên kết đến bảng KhoHang

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>(); // Liên kết đến bảng OrderDetail
    }
}
