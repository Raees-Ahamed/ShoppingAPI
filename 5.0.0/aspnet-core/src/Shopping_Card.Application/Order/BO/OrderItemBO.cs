using Shopping_Card.Product.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Card.Order.BO
{
    public class OrderItemBO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductBO Products { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public int OrderId { get; set; }
        public bool IsDelete { get; set; }
    }
}
