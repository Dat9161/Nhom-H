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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public OrderDetailRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Add(orderDetail);
            _dbContext.SaveChanges();
        }
    }
}