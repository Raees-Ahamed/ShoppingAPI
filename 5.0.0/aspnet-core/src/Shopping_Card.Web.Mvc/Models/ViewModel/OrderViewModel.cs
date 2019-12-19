using Shopping_Card.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Card.Web.Models.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public CustomerViewModel Customer { get; set; }
    }
}
