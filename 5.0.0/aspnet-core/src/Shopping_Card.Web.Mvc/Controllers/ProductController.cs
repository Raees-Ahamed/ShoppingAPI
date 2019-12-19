using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopping_Card.Controllers;
using Shopping_Card.Product;
using Shopping_Card.Web.Models.ViewModel;

namespace Shopping_Card.Web.Controllers
{
    public class ProductController : Shopping_CardControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

      
        public JsonResult GetProductById(int id)
        {
            var productDto = productService.GetProductById(id);
            var product = ObjectMapper.Map<ProductViewModel>(productDto);
            return Json(product);           
        }
    }
}