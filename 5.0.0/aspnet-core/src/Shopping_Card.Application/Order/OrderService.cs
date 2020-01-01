using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping_Card.Order.BO;
using Shopping_Card.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping_Card.Order
{
    public class OrderService : IOrderService
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        private readonly IRepository<Entities.Order> repository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IProductService productService,IMapper mapper,IRepository<Entities.Order> repository,IUnitOfWork unitOfWork)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void ChangeOrder(OrderBO orderBO)
        {
            var tempOrder = repository.GetAllIncluding().Include(o=>o.OrderItems).First(i=>i.Id==orderBO.Id);

            foreach (var items in orderBO.OrderItems)
            {
               var tempOrderLine = tempOrder.OrderItems.FirstOrDefault(f => f.Id == items.Id);
               var isDelete = orderBO.OrderItems.FirstOrDefault(f => f.Id == items.Id).IsDelete;
               var tempDifference = tempOrderLine.Qty - items.Qty;

                tempOrderLine.ProductId = items.ProductId;
                tempOrderLine.Qty = items.Qty;

                if (isDelete)
                {
                    var orderItem = tempOrder.OrderItems.FirstOrDefault(o => o.Id == items.Id);
                    tempOrder.OrderItems.Remove(orderItem);
                }

                productService.Update(items.ProductId, tempDifference);
                repository.Update(tempOrder);
            }
            unitOfWork.SaveChanges();
        }

        public int CreateOrder(OrderBO order)
        {
            var orderBOTemp = order.Create(order.CustomerId, order.Date, order.OrderItems);
            var Order = mapper.Map<Entities.Order>(orderBOTemp);            
            repository.Insert(Order);
            unitOfWork.SaveChanges();
            return Order.Id;
        }

        public void DeleteOrder(int id)
        {
            var orderBo = repository.Get(id);
            var DeleteOrder = mapper.Map<Entities.Order>(orderBo);
            repository.Delete(DeleteOrder);           
        }

        public IEnumerable<OrderBO> GetAllOrders()
        {
            var orders = repository.GetAll();
            var query = mapper.Map<IEnumerable<OrderBO>>(orders);
            return query;
        }

        public OrderBO GetOrdersById(int id)
        {         
            var Orders = repository.GetAllIncluding().Include(i => i.OrderItems).First(o => o.Id == id);
            return mapper.Map<OrderBO>(Orders);
        }
    }
}
