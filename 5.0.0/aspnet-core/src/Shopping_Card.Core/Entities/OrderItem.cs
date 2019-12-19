using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shopping_Card.Entities
{
    public class OrderItem : Entity<int>
    {
        public int Qty { get; set; }

        public int Price { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Products { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Orders { get; set; }
    }
}
