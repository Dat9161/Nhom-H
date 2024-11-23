using KoiFarmShop.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KoiFarmShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public ProductRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext; // Inject DbContext
        }

        // Lấy tất cả sản phẩm
        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList(); // Truy vấn lấy danh sách sản phẩm
        }

        // Lấy sản phẩm theo ID
        public List<Product> GetProductsByCategory(string categoryId)
        {
            return _dbContext.Products.Where(p => p.CategoryId == categoryId).ToList(); // Sử dụng CategoryId
        }


        // Thêm sản phẩm mới
        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product); // Thêm sản phẩm vào DbContext
            _dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Cập nhật thông tin sản phẩm
        public void UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product); // Cập nhật sản phẩm
            _dbContext.SaveChanges(); // Lưu thay đổi
        }

        // Xóa sản phẩm
        public void DeleteProduct(string productId)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == productId); // Tìm sản phẩm theo ID
            if (product != null)
            {
                _dbContext.Products.Remove(product); // Xóa sản phẩm
                _dbContext.SaveChanges(); // Lưu thay đổi
            }
        }
        public Product GetProductById(string productId)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
