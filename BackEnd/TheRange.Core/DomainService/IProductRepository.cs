using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity;
using TheRange.Core.Entity.Mens;

namespace TheRange.Core.DomainService
{
    public interface IProductRepository
    {
        Product NewProduct(string Size, string Colour, string Brand, string Type, Decimal Price);
        Product CreateProduct(Product product);
        List<Product> ReadById(int Id);
        List<Product> ReadAll();
        void UpdateProduct(int Id, Product productValue);
        Product DeleteProduct(int Id);
        Product SearchProduct(Product product);
        List<Product> SortProductByColour();
        List<Product> SortProductByType();

    }
}
