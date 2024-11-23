using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;

namespace KoiFarmShop.Services
{
    public interface IProductServices
    {
        List<Product> GetAllProducts(); // Lấy tất cả sản phẩm
        List<Product> GetProductsByCategory(string categoryId); // Lấy sản phẩm theo ID
        void AddProduct(Product product); // Thêm sản phẩm mới
        void UpdateProduct(Product product); // Cập nhật sản phẩm
        void DeleteProduct(string productId); // Xóa sản phẩm
        Product GetProductById(string productId); // Lấy thông tin sản phẩm theo ProductId
    }
}
