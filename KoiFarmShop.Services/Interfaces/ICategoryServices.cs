using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services
{
    public interface ICategoryServices
    {
        Category GetCategoryById(string categoryId); // Lấy thông tin danh mục sản phẩm theo CategoryId
    }
}
