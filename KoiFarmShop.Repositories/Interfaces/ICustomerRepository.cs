using KoiFarmShop.Repositories.Entities;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerByEmailAsync(string email);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
    }
}
