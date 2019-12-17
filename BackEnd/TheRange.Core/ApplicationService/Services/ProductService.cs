using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheRange.Core.DomainService;
using TheRange.Core.Entity;
using TheRange.Core.Entity.Mens;
using Type = TheRange.Core.Entity.Type;

namespace TheRange.Core.ApplicationService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public Product DeleteProduct(int Id)
        {
            return _productRepository.DeleteProduct(Id);
        }

        public Product NewProduct(string Size, string Colour, string Brand, Type Type, decimal Price)
        {
            Product product = new Product() {Size = Size, Colour = Colour, Brand = Brand, Type = Type, Price = Price};
            return product;
        }

        public List<Product> ReadAll()
        {
            return _productRepository.ReadAll().ToList();
        }

        public Product ReadByID(int Id)
        {
            return _productRepository.ReadById(Id);
        }

        public List<Product> SortProductByType(Type type)
        {
            var list = _productRepository.ReadAll();
            var listByType = list.Where(Product => Product.Type.Equals(type));
            return listByType.ToList();
        }

        public List<Product> SortProductByType()
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(int Id, Product productValue)
        {
            _productRepository.UpdateProduct(Id, productValue);
            return null;
        }
    }


}

