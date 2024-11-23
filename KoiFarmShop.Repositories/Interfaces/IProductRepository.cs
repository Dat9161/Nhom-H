using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts(); // Lấy tất cả sản phẩm
        List<Product> GetProductsByCategory(string categoryId); // Lấy sản phẩm theo ID
        void AddProduct(Product product); // Thêm sản phẩm mới
        void UpdateProduct(Product product); // Cập nhật thông tin sản phẩm
        void DeleteProduct(string productId); // Xóa sản phẩm
        Product GetProductById(string productId); // Lấy sản phẩm theo ProductId

    }
}
