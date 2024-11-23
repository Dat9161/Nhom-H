using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public CustomerRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email không được để trống.");
            }

            return await _dbContext.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            _ = customer ?? throw new ArgumentNullException(nameof(customer));

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}
