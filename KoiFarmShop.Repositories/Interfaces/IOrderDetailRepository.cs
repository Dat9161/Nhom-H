using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        void Add(OrderDetail orderDetail);  // Thêm chi tiết đơn hàng

    }
}