using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using APM.WebAPI.Models;

namespace APM.WebAPI.Controllers
{
    [EnableCors("http://localhost:24322", "*", "*")]
    public class ProductsController : ApiController
    {
        [EnableQuery]
        // GET: api/Products
        public IQueryable<Product> Get()
        {
            ProductRepository productRepository = new ProductRepository();
            return productRepository.Retrieve().AsQueryable();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            Product product;
            var productRepository = new ProductRepository();

            if (id > 0)
            {
                var products = productRepository.Retrieve();
                product = products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                product = productRepository.Create();
            }
            return product;
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            ProductRepository productRepository = new ProductRepository();
            if (product != null)
            {
                Product newProduct = productRepository.Save(product);
            }
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product)
        {
            ProductRepository productRepository = new ProductRepository();
            if (product != null && id > 0 )
            {
                Product newProduct = productRepository.Save(id, product);
            }

        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
