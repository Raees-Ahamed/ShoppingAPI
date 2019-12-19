﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopping_Card.Controllers;
using Shopping_Card.Customer;
using Shopping_Card.Order;
using Shopping_Card.Order.BO;
using Shopping_Card.OrderItem;
using Shopping_Card.Product;
using Shopping_Card.Web.Models.ViewModel;

namespace Shopping_Card.Web.Controllers
{
    public class OrderController : Shopping_CardControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;
        private readonly IOrderItemService orderItemService;

        public OrderController(ICustomerService customerService,IProductService productService,IOrderService orderService,IMapper mapper,IOrderItemService orderItemService)
        {
            this.customerService = customerService;
            this.productService = productService;
            this.orderService = orderService;
            this.mapper = mapper;
            this.orderItemService = orderItemService;
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            ViewBag.ListOfCustomers = customerService.GetAllCustomer().ToList();
            ViewBag.ListOfProducts = productService.GetAllProducts().ToList();
            return View();
        }


        [HttpGet]
        public IActionResult GetAllOrders() {
            var orders = orderService.GetAllOrders().ToList();
            var AllOrders = mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return View(AllOrders);
        }

        [HttpGet]
        public IActionResult RemoveOrders(int id)
        {
            orderService.DeleteOrder(id);
            return RedirectToAction("GetAllOrders", "Order");
        }

        [HttpGet]
        public IActionResult GetOrdersById(int id) {
            ViewBag.Products = productService.GetAllProducts();
            var orderItems = orderService.GetOrdersById(id);
            var items = mapper.Map<OrderViewModel>(orderItems);
            return View(items);
        }

        [HttpGet]
        public IActionResult DeleteOrderItems(int id) {
            orderItemService.DeleteOrderItem(id);
            return RedirectToAction("GetAllOrders","Order");
        }

        [HttpPost]
        public IActionResult ChangeOrder([FromBody]OrderViewModel orderViewModel) {
            var order = mapper.Map<OrderBO>(orderViewModel);
            orderService.ChangeOrder(order);
            return RedirectToAction("GetAllOrders", "Order");
        }
    }
}