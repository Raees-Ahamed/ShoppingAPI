using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Shopping_Card.Customer.BO
{
    class CustomerBOMapper : Profile
    {        
        public CustomerBOMapper()
        {
            CreateMap<CustomerBO, Entities.Customer>().ReverseMap();
        }
    }
}
