using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeServices(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Employee>> Employee()
        {
            return _repository.GetAllEmployee();
        }
    }
}

