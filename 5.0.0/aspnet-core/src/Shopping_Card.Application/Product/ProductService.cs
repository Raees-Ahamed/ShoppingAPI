using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Shopping_Card.Product.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Card.Product
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Entities.Product> products;
        private readonly IMapper mapper;
      

        public ProductService(IRepository<Entities.Product> products,IMapper mapper)
        {
            this.products = products;
            this.mapper = mapper;
            
        }
        public IEnumerable<ProductBO> GetAllProducts()
        {
            var product = products.GetAll();
            var query = mapper.Map<IEnumerable<ProductBO>>(product);
            return query;
        }

        public ProductBO GetProductById(int id)
        {
            var product = products.Get(id);
            var query = mapper.Map<ProductBO>(product);
            return query;
        }

        public void Update(int productId, int quantity)
        {
            var productBO = products.Get(productId);
            productBO.QtyInHand += quantity;
            var product = mapper.Map<Entities.Product>(productBO);
            products.Update(product);
        }
    }
}
