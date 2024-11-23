using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using KoiFarmShop.WebApplication.Models;
using KoiFarmShop.WebApplication.Extensions;
using System.Linq;

namespace KoiFarmShop.WebApplication.Pages
{
    public class GioHangModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCart Cart { get; set; }

        public GioHangModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            // Lấy giỏ hàng từ session (nếu có)
            Cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();
        }

        // Phương thức để thêm sản phẩm vào giỏ hàng
        public IActionResult OnPostAddToCart(string productId, string productName, decimal price)
        {
            // Lấy giỏ hàng từ session (nếu có)
            Cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();

            // Kiểm tra xem sản phẩm đã có trong giỏ chưa
            var existingItem = Cart.Items.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++; // Tăng số lượng nếu sản phẩm đã có trong giỏ
            }
            else
            {
                Cart.Items.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = 1
                });
            }

            // Lưu giỏ hàng vào session
            _httpContextAccessor.HttpContext.Session.SetObjectAsJson("ShoppingCart", Cart);

            // Quay lại trang giỏ hàng sau khi thêm sản phẩm
            return RedirectToPage("/GioHang");
        }

        // Phương thức để xóa sản phẩm khỏi giỏ hàng
        public IActionResult OnPostDeleteItem(string productId)
        {
            // Lấy giỏ hàng từ session
            Cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();

            // Tìm và xóa sản phẩm trong giỏ hàng
            var itemToRemove = Cart.Items.FirstOrDefault(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                Cart.Items.Remove(itemToRemove);
            }

            // Lưu giỏ hàng vào session
            _httpContextAccessor.HttpContext.Session.SetObjectAsJson("ShoppingCart", Cart);

            // Trở lại trang giỏ hàng sau khi xóa
            return RedirectToPage();
        }
    }
}
