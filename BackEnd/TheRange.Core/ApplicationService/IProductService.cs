using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity;
using TheRange.Core.Entity.Mens;
using Type = TheRange.Core.Entity.Type;

namespace TheRange.Core.ApplicationService
{
    public interface IProductService
    {
        Product NewProduct(string Size, string Colour, string Brand, Type Type, Decimal Price);
        Product CreateProduct(Product product);
        Product ReadByID(int Id);
        List<Product> ReadAll();
        Product UpdateProduct(int Id, Product product);
        Product DeleteProduct(int Id);
        List<Product> SortProductByType(Type type);


    }
}

