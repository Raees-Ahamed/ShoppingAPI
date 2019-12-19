using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Card.OrderItem
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Entities.OrderItem> repository;
       
        public OrderItemService(IMapper mapper,IRepository<Entities.OrderItem> repository)
        {
            this.mapper = mapper;
            this.repository = repository;            
        }

        public void DeleteOrderItem(int id)
        {
            var orderItems = repository.Get(id);
            var DeleteOrderItems = mapper.Map<Entities.OrderItem>(orderItems);
            repository.Delete(DeleteOrderItems);
        }
    }
}
