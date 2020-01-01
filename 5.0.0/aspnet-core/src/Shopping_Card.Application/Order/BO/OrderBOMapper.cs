using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Card.Order.BO
{
    public class OrderBOMapper : Profile
    {
        public OrderBOMapper()
        {
            CreateMap<OrderBO, Entities.Order>().ReverseMap();
            CreateMap<OrderItemBO, Entities.OrderItem>().ReverseMap();
            CreateMap<OrderBO, OrderItemBO>().ReverseMap();
            CreateMap<Entities.Order, Entities.OrderItem>().ReverseMap();
            CreateMap<Entities.Order, OrderItemBO>().ReverseMap();
            CreateMap<Entities.OrderItem,OrderBO>().ReverseMap();
        }      
    }
}
