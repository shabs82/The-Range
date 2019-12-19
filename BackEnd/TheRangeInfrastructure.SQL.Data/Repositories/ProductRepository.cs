using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TheRange.Core.DomainService;
using TheRange.Core.Entity;

namespace TheRange.Infrastructure.SQL.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TheRangeContext _ctx;

        public ProductRepository(TheRangeContext ctx)
        {
            _ctx = ctx ;
        }

        public Product NewProduct(string Size, string Colour, string Brand, Type Type, decimal Price)
        {
            throw new NotImplementedException();
        }

        public Product CreateProduct(Product newProduct)
        {
            _ctx.Products.Attach(newProduct).State = EntityState.Added;
            _ctx.SaveChanges();
            return newProduct;
        }

        public Product DeleteProduct(int productId)
        {
            var productToDelete = _ctx.Products.FirstOrDefault(p => p.Id == productId);
            _ctx.Products.Remove(productToDelete);
            _ctx.SaveChanges();
            return productToDelete;
        }

        public Product NewProduct(string Size, string Colour, string Brand, ClothType Type, decimal Price)
        {
            return null;
        }

        public IEnumerable<Product> ReadAll()
        {
            return _ctx.Products;
        }

        public Product ReadById(int Id)
        {
            return _ctx.Products.AsNoTracking().Include(p=> p.Order).FirstOrDefault(p => p.Id == Id);
        }
        public IEnumerable<Product> SortProductByType(ClothType type)
        {
           return ReadAll().Where(t => t.Type == type);
            
        }

        public Product UpdateProduct(int Id, Product updatedProduct)
        {
            _ctx.Products.Attach(updatedProduct).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedProduct;

        }
    }
}
