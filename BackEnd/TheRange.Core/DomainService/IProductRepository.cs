using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity;
using TheRange.Core.Entity.Mens;
using Type = TheRange.Core.Entity.Type;

namespace TheRange.Core.DomainService
{
    public interface IProductRepository
    {
        Product NewProduct(string Size, string Colour, string Brand, Type Type, Decimal Price);
        Product CreateProduct(Product product);
        Product ReadById(int Id);
        IEnumerable<Product> ReadAll();
        void UpdateProduct(int Id, Product productValue);
        Product DeleteProduct(int Id);
        IEnumerable<Product> SortProductByType();

    }
}
