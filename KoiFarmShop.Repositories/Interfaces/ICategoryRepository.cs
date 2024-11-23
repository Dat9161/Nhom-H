using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(string categoryId); // Lấy thông tin danh mục sản phẩm theo CategoryId
    }
}
