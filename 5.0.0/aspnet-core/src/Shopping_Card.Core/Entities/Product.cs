using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopping_Card.Entities
{
    public class Product : Entity<int>
    {
        public string Name { get; set; }
        [Required]
        [MaxLength(60)]
        public string Description { get; set; }
        public int QtyInHand { get; set; }
        public int UnitPrice { get; set; }
    }
}
