using KoiFarmShop.Repositories;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetCategoryById(string categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId); // Lấy thông tin danh mục sản phẩm
        }
    }
}
