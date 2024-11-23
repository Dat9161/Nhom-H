using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Services;
using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Linq;

namespace KoiFarmShop.WebApplication.Pages
{
    public class sanphamModel : PageModel
    {
        private readonly IProductServices _productServices;

        public List<Product> Products { get; set; }
        public string SearchQuery { get; set; }

        public sanphamModel(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public void OnGet(string search)
        {
            var allProducts = _productServices.GetAllProducts(); // Lấy tất cả sản phẩm từ dịch vụ

            if (!string.IsNullOrEmpty(search))
            {
                // Tìm kiếm theo tên sản phẩm và mã danh mục
                Products = allProducts.Where(p =>
                    p.ProductName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    (p.CategoryId != null && p.CategoryId.Contains(search, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }
            else
            {
                // Nếu không có từ khóa tìm kiếm, lấy tất cả sản phẩm
                Products = allProducts;
            }
        }


    }
}
