using AutoMapper;
using Shopping_Card.Order.BO;
using Shopping_Card.OrderItem.BO;
using Shopping_Card.Product.BO;
using Shopping_Card.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Card.Web.Host.AutoMapper
{
    public class ViewModelAutoMapper : Profile
    {
        public ViewModelAutoMapper()
        {
            CreateMap<ProductViewModel, ProductBO>().ReverseMap();
            CreateMap<OrderViewModel, OrderBO>().ReverseMap();
            CreateMap<OrderViewModel, OrderItemViewModel>().ReverseMap();
            CreateMap<OrderItemViewModel, OrderItemBO>().ReverseMap();
            CreateMap<OrderBO, OrderItemBO>().ReverseMap();
        }
    }
}
