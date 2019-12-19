using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity;

namespace TheRange.Core.DomainService
{
    public interface IProductRepository
    {
        Product NewProduct(string Size, string Colour, string Brand, ClothType Type, Decimal Price);
        Product CreateProduct(Product product);
        Product ReadById(int Id);
        IEnumerable<Product> ReadAll();
        Product UpdateProduct(int Id, Product productValue);
        Product DeleteProduct(int Id);
        IEnumerable<Product> SortProductByType(ClothType type);

    }
}
