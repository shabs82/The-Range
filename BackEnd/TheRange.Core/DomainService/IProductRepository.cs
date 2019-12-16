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
        List<Product> ReadByID(Product product);
        List<Product> ReadAll();
        void UpdateProduct(int Id, Product product);
        void DeleteProduct(int Id);
        Sweatshirts SearchProduct(Product product);
        List<Product> SortProductByColour();
        List<Product> SortProductByType();

    }
}
