using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopping_Card.Entities
{
    public class Customer:Entity<int>
    {
        public string Fname { get; set; }
        [Required]
        [MaxLength(60)]
        public string Lname { get; set; }

        public int Telephone { get; set; }
        [Required]
        [MaxLength(60)]
        public string Address { get; set; }
    }
}
