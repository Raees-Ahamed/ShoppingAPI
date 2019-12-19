using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shopping_Card.Entities
{
    public class Order : Entity<int>
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
