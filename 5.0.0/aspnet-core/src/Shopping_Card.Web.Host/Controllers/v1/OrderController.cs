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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shopping_Card.Web.Host.Controllers.v1
{

    [Route("api/[controller]")]
    public class OrderController : Shopping_CardControllerBase
    {
        private readonly IMapper mapper;
        private readonly IOrderService orderService;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            this.mapper = mapper;
            this.orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderViewModel orderViewModel)
        {
            var order = mapper.Map<OrderBO>(orderViewModel);
            orderService.CreateOrder(order);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]OrderViewModel orderViewModel)
        {
            var order = mapper.Map<OrderBO>(orderViewModel);
            orderService.ChangeOrder(order);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                orderService.DeleteOrder(id);
                TempData["Message"] = "You have deleted the order Ref No: " + id + " successfully!";
                return Ok("Deleted successfully!");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error occured while deleting the order " + id + "! " + ex;
                throw new Exception();
            }
        }
    }
}
