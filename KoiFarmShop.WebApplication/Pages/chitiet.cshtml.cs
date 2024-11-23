using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Linq;
using KoiFarmShop.WebApplication.Extensions;
using KoiFarmShop.WebApplication.Models;

namespace KoiFarmShop.WebApplication.Pages
{
    public class chitietModel : PageModel
    {
        private readonly IProductServices _productServices;
        private readonly IKhoHangServices _khoHangServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Product Product { get; set; }
        public Category Category { get; set; }
        public KhoHang Stock { get; set; }

        public chitietModel(IProductServices productServices, IKhoHangServices khoHangServices, ICategoryServices categoryServices, IHttpContextAccessor httpContextAccessor)
        {
            _productServices = productServices;
            _khoHangServices = khoHangServices;
            _categoryServices = categoryServices;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet(string id)
        {
            // Lấy thông tin sản phẩm từ dịch vụ sản phẩm
            Product = _productServices.GetProductById(id);

            // Kiểm tra nếu không tìm thấy sản phẩm
            if (Product == null)
            {
                // Chuyển hướng về trang lỗi nếu không tìm thấy sản phẩm
                RedirectToPage("/Error");
                return;
            }

            // Lấy thông tin danh mục từ dịch vụ danh mục
            Category = _categoryServices.GetCategoryById(Product.CategoryId);

            // Lấy thông tin kho hàng từ dịch vụ kho hàng
            Stock = _khoHangServices.GetProductStock(Product.ProductId);
        }

        public IActionResult OnPostAddToCart(string productId, int quantity)
        {
            // Kiểm tra xem người dùng đã đăng nhập qua cookie chưa
            var user = User;  // Lấy thông tin người dùng từ cookie

            if (!user.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Bạn phải đăng nhập để truy cập trang này.";
                return RedirectToPage("dang_nhap");
            }

            // Lấy thông tin sản phẩm từ dịch vụ sản phẩm
            Product = _productServices.GetProductById(productId);

            // Kiểm tra nếu sản phẩm không tồn tại
            if (Product == null)
            {
                return RedirectToPage("/Error");
            }

            // Lấy thông tin kho hàng từ dịch vụ kho hàng
            Stock = _khoHangServices.GetProductStock(Product.ProductId);

            // Kiểm tra số lượng yêu cầu có lớn hơn số lượng trong kho không
            if (quantity > Stock.Quantity)
            {
                TempData["ErrorMessage"] = "Số lượng sản phẩm yêu cầu vượt quá số lượng trong kho.";
                return RedirectToPage("/chitiet", new { id = productId }); // Quay lại trang chi tiết sản phẩm
            }

            // Lấy giỏ hàng từ session (nếu có), nếu không thì tạo mới giỏ hàng
            var cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();

            // Kiểm tra nếu sản phẩm đã có trong giỏ hàng thì tăng số lượng
            var existingItem = cart.Items.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                // Thêm sản phẩm mới vào giỏ hàng
                cart.Items.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = Product.ProductName, // Tên sản phẩm
                    Price = (decimal)Product.Price, // Giá của sản phẩm
                    Quantity = quantity
                });
            }

            // Lưu giỏ hàng lại vào session
            _httpContextAccessor.HttpContext.Session.SetObjectAsJson("ShoppingCart", cart);

            // Điều hướng người dùng đến trang giỏ hàng
            return RedirectToPage("/gioHang");
        }

    }
}
