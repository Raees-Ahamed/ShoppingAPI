using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Card.Web.Models.ViewModel 
{ 
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Telephone { get; set; }
        public string Address { get; set; }
    }
}
