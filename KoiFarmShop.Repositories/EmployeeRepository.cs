using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public EmployeeRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _dbContext.Employees.ToListAsync();
        }
    }
}