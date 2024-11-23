using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories
{
    public interface IKhoHangRepository
    {
        KhoHang GetProductStock(string productId); // Lấy thông tin kho của sản phẩm
    }
}
