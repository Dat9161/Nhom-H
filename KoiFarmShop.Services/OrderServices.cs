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
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderServices(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public string CreateOrder(string userId, string address, string phone, string email)
        {
            var order = new Order
            {
                OrderId = Guid.NewGuid().ToString(), // Tạo ID đơn hàng ngẫu nhiên
                IdUser = userId,
                Address = address,
                Phone = phone,
                Email = email,
                
            };

            _orderRepository.Add(order);  // Lưu đơn hàng vào cơ sở dữ liệu

            return order.OrderId;  // Trả về OrderId
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
