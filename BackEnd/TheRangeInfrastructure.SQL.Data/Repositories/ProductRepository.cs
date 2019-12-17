using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.DomainService;
using TheRange.Core.Entity;
using TheRange.Core.Entity.Mens;

namespace TheRange.Infrastructure.SQL.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public Product NewProduct(string Size, string Colour, string Brand, string Type, decimal Price)
        {
            throw new NotImplementedException();
        }

        public List<Product> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> ReadById(int Id)
        {
            throw new NotImplementedException();
        }

        public Product SearchProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> SortProductByColour()
        {
            throw new NotImplementedException();
        }
        public List<Product> SortProductByType()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int Id, Product productValue)
        {
            throw new NotImplementedException();
        }
    }
}
