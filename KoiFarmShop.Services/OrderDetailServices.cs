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
    public class OrderDetailServices : IOrderDetailServices
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailServices(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public void AddOrderDetail(string orderId, string productId, string productName, int quantity, decimal price, decimal total)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = orderId,
                ProductId = productId,
                ProductName = productName,
                Quantity = quantity,
                Price = price,
                Total = total
            };

            _orderDetailRepository.Add(orderDetail);  // Lưu chi tiết đơn hàng vào cơ sở dữ liệu
        }
    }
}

