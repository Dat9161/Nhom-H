using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories;
using System.Collections.Generic;

namespace KoiFarmShop.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts(); // Gọi phương thức từ repository
        }

        List<Product> IProductServices.GetProductsByCategory(string categoryId)
        {
            return _productRepository.GetProductsByCategory(categoryId); // Gọi phương thức từ repository
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product); // Gọi phương thức từ repository
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product); // Gọi phương thức từ repository
        }

        public void DeleteProduct(string productId)
        {
            _productRepository.DeleteProduct(productId); // Gọi phương thức từ repository
        }
        public Product GetProductById(string productId)
        {
            return _productRepository.GetProductById(productId); // Lấy thông tin sản phẩm
        }
    }
}
