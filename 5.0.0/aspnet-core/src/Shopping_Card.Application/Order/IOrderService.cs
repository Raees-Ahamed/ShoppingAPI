using Shopping_Card.Order.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Card.Order
{
    public interface IOrderService
    {
        public int CreateOrder(OrderBO order);
        public IEnumerable<OrderBO> GetAllOrders();
        public void DeleteOrder(int id);
        public OrderBO GetOrdersById(int id);
        public void ChangeOrder(OrderBO orderBO);
    }
}
