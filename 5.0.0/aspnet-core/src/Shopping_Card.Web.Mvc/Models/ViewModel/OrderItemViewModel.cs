using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Card.Web.Models.ViewModel
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Products { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public int OrderId { get; set; }
        public bool IsDelete { get; set; }
    }
}
