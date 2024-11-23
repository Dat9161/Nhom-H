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
    public class OrderRepository : IOrderRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public OrderRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
}