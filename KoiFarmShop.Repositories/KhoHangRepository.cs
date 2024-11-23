using KoiFarmShop.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories
{
    public class KhoHangRepository : IKhoHangRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public KhoHangRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public KhoHang GetProductStock(string productId)
        {
            // Truy vấn sản phẩm theo ProductId trong bảng KhoHang
            return _dbContext.KhoHangs.FirstOrDefault(kh => kh.ProductId == productId);
        }
    }
}
