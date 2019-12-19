using Shopping_Card.Customer.BO;
using Shopping_Card.OrderItem.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Card.Order.BO
{
    public class OrderBO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerBO CustomerBO { get; set; }
        public virtual List<OrderItemBO> OrderItems { get; set; }

        public OrderBO Create(int customerId, DateTime dateTime, List<OrderItemBO> orderItemsBO)
        {
            CustomerId = customerId;
            Date = dateTime;
            OrderItems = orderItemsBO;
            
            foreach (var item in orderItemsBO)
            {
                if (item.Qty == 0)
                {
                    throw new Exception();
                }
            }
            return this;
        }
    }
}
