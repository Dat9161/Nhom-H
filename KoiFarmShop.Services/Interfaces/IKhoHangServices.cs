using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services
{
    public interface IKhoHangServices
    {
        KhoHang GetProductStock(string productId); // Lấy thông tin kho của sản phẩm
    }
}
