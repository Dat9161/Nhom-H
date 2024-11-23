using KoiFarmShop.Repositories;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services
{
    public class KhoHangServices : IKhoHangServices
    {
        private readonly IKhoHangRepository _khoHangRepository;

        public KhoHangServices(IKhoHangRepository khoHangRepository)
        {
            _khoHangRepository = khoHangRepository;
        }

        public KhoHang GetProductStock(string productId)
        {
            return _khoHangRepository.GetProductStock(productId); // Lấy thông tin kho của sản phẩm
        }
    }
}
