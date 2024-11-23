using KoiFarmShop.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public CategoryRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category GetCategoryById(string categoryId)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }
    }
}
