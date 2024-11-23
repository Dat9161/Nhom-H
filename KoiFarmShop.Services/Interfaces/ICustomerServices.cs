using KoiFarmShop.Repositories.Entities;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Interfaces
{
    public interface ICustomerServices
    {
        Task<Customer?> LoginAsync(string email, string password); // Đăng nhập
        Task<bool> RegisterAsync(Customer customer); // Đăng ký
        Task<bool> UpdateCustomerAsync(Customer customer); // Cập nhật thông tin
        Task<Customer?> GetCustomerByEmailAsync(string email); // Lấy thông tin khách hàng theo email
    }
}
