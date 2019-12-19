using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Final_exam_project.core.DomainService;
using TheRange.Core.DomainService;
using TheRange.Core.Entity;
using TheRange.Core.Entity.Mens;

namespace TheRange.Core.ApplicationService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        //Nice constructor
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public Product DeleteProduct(int Id)
        {
            return _productRepository.DeleteProduct(Id);
        }

        public Product NewProduct(string Size, string Colour, string Brand, ClothType Type, decimal Price)
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

        public List<Product> SortProductByType(ClothType type)
        {
            var list = _productRepository.ReadAll();
            var listByType = list.Where(P => P.Type == (type));
            return listByType.ToList();
        }

        public Product UpdateProduct(int Id, Product productValue)
        { 
           return _productRepository.UpdateProduct(Id, productValue);
            
        }
    }


}

