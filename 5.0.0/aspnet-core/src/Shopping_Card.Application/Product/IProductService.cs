using Shopping_Card.Product.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Card.Product
{
    public interface IProductService
    {
        public IEnumerable<ProductBO> GetAllProducts();
        ProductBO GetProductById(int id);
        public void Update(int productId, int quantity);
    }
}
