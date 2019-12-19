using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopping_Card.Controllers;
using Shopping_Card.Order;
using Shopping_Card.Order.BO;
using Shopping_Card.Web.Models.ViewModel;

namespace Shopping_Card.Web.Host.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : Shopping_CardControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrderController(IOrderService orderService,IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderViewModel orderViewModel)
        {
            var order = mapper.Map<OrderBO>(orderViewModel);
            orderService.CreateOrder(order);
            return RedirectToAction("GetAllOrders", "Order");
        }
    }
}