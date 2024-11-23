using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Interfaces
{
    public interface IOrderServices
    {
        string CreateOrder(string userId, string address, string phone, string email);  // Tạo đơn hàng
        void AddOrderDetail(string orderId, string productId, string productName, int quantity, decimal price, decimal total);  // Thêm chi tiết đơn hàng
    }
}
