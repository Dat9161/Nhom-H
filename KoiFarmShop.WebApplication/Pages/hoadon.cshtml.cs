using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using KoiFarmShop.WebApplication.Models;
using KoiFarmShop.WebApplication.Extensions;
using System.Linq;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.WebApplication.Pages
{
    public class HoaDonModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderServices _orderServices;
        private readonly IOrderDetailServices _orderDetailServices;

        public ShoppingCart Cart { get; set; }

        public HoaDonModel(IHttpContextAccessor httpContextAccessor, IOrderServices orderServices, IOrderDetailServices orderDetailServices)
        {
            _httpContextAccessor = httpContextAccessor;
            _orderServices = orderServices;
            _orderDetailServices = orderDetailServices;
        }

        public void OnGet()
        {
            // Lấy giỏ hàng từ session (nếu có)
            Cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();
        }

        public IActionResult OnPostPlaceOrder(string userId, string address, string phone, string email)
        {
            // Lấy giỏ hàng từ session
            Cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart");
            var sessionUserId = _httpContextAccessor.HttpContext.Session.GetString("IdUser");
            // Kiểm tra xem giỏ hàng có chứa sản phẩm hay không
            if (Cart == null || !Cart.Items.Any())
            {
                TempData["ErrorMessage"] = "Giỏ hàng của bạn trống, không thể đặt hàng.";
                return RedirectToPage("/hoaDon");
            }

            // Tạo đơn hàng và lấy OrderId
            var orderId = _orderServices.CreateOrder(sessionUserId, address, phone, email);

            // Lưu chi tiết đơn hàng
            foreach (var item in Cart.Items)
            {
                var total = item.Price * item.Quantity;
                _orderDetailServices.AddOrderDetail(orderId, item.ProductId, item.ProductName, item.Quantity, item.Price, total);
            }

            // Làm trống giỏ hàng trong session sau khi đặt hàng
            _httpContextAccessor.HttpContext.Session.Remove("ShoppingCart");

            // Thông báo thành công
            TempData["SuccessMessage"] = "Đặt hàng thành công!";

            // Chuyển hướng về trang chủ
            return RedirectToPage("/trangchu");
        }

    }
}
