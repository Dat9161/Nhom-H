namespace KoiFarmShop.WebApplication.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public string ProductId { get; set; }  // ID sản phẩm
        public string ProductName { get; set; } // Tên sản phẩm
        public decimal Price { get; set; } // Giá sản phẩm
        public int Quantity { get; set; } // Số lượng sản phẩm
    }
}
