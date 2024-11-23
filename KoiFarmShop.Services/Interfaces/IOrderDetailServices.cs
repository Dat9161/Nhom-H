using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IOrderDetailServices
    {
        void AddOrderDetail(string orderId, string productId, string productName, int quantity, decimal price, decimal total);  // Thêm chi tiết đơn hàng
    }
}