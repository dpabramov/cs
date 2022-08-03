using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineStore.App
{
    public interface IOrderRepository
    {
        int GetOrderCount();

        List<OrderDiscount> GetOrderDiscountList();

        int AddOrder(int customerId,
                DateTimeOffset orderDate,
                float? discount,
                List<Tuple<int, int>> productIdCountList);
    }
}
