using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Card.Product.BO
{
    public class ProductBOMapper : Profile
    {
        public ProductBOMapper()
        {
            CreateMap<ProductBO, Entities.Product>().ReverseMap();
        }
    }
}
