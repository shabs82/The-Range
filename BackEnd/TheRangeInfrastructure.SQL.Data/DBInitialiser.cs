using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TheRange.Core.Entity;
using TheRange.Core.Helper;
using Type = TheRange.Core.Entity.Type;

namespace TheRange.Infrastructure.SQL.Data
{
    public class DBInitialiser : IDBInitialiser
    {
        private readonly IAuthenticationHelper _authenticationHelper;


        public DBInitialiser(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }
        public void Seed(TheRangeContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            
            string password = "1234";
            _authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashAdmin, out byte[] passwordSaltAdmin);
            _authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashUser, out byte[] passwordSaltUser);


            User user1 = new User()
            {
                Username = "shabs",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true
            };

            User user2 = new User()
            {
                Username = "Megan",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = false
            };
            ctx.Users.Add(user1);
            ctx.Users.Add(user2);

            var User1 = new User { Username = "Admin", PasswordHash = passwordHashAdmin, PasswordSalt = passwordSaltAdmin, IsAdmin = true };
            var User2 = new User { Username = "User", PasswordHash = passwordHashUser, PasswordSalt = passwordSaltUser, IsAdmin = false };

            var cust1 = ctx.Customers.Add(new Customer()
            {   

                FirstName = "Craig ",
                LastName = "Newton",
                Address = "bungalow street 43",
                PhoneNumber = "3456789",
                Email = "abc@live.co.uk",
            }).Entity;

            var cust2 = ctx.Customers.Add(new Customer()
            {

                FirstName = "Jack",
                LastName = "Taylor",
                Address = "romastrasse 55",
                PhoneNumber = "1235698",
                Email = "xyz@live.co.uk"

            }).Entity;
            var cust3 = ctx.Customers.Add(new Customer()
            {
                FirstName = "Zack",
                LastName = "Cook",
                Address = "windsor 214",
                PhoneNumber = "254897",
                Email = "smt@live.co.uk",
            }).Entity;

            var prod1 = ctx.Products.Add(new Product()
            {
                 Size = "s",
                 Colour = "Grey",
                 Brand = "Boss",
                 Type = Type.Sweatshirt,
                 Price = 25
            }).Entity;

            var prod2 = ctx.Products.Add(new Product()
            {
                Size = "m",
                Colour = "Grey",
                Brand = "Boss",
                Type = Type.Sweatshirt,
                Price = 25
            }).Entity;

            var prod3 = ctx.Products.Add(new Product()
            {
                Size = "l",
                Colour = "Grey",
                Brand = "Boss",
                Type = Type.Sweatshirt,                
                Price = 25
            }).Entity;

            var prod4 = ctx.Products.Add(new Product()
            {
                Size = "s",
                Colour = "Grey",
                Brand = "Boss",
                Type = Type.Top,
                Price = 25
            }).Entity;
            var prod5 = ctx.Products.Add(new Product()
            {
                Size = "m",
                Colour = "Grey",
                Brand = "Boss",
                Type = Type.Top,
                Price = 25
            }).Entity;
            var prod7 = ctx.Products.Add(new Product()
            {
                Size = "l",
                Colour = "Grey",
                Brand = "Boss",
                Type = Type.Top,
                Price = 25
            }).Entity;

            var prod8 = ctx.Products.Add(new Product()
            {
                Size = "s",
                Colour = "Black",
                Brand = "Boss",
                Type = Type.Tshirt,
                Price = 25
            }).Entity;

            var prod9 = ctx.Products.Add(new Product()
            {
                Size = "m",
                Colour = "Black",
                Brand = "Boss",
                Type = Type.Tshirt,
                Price = 25
            }).Entity;

            var prod10 = ctx.Products.Add(new Product()
            {
                Size = "l",
                Colour = "Black",
                Brand = "Boss",
                Type =Type.Tshirt,
                Price = 25
            }).Entity;

            var prod11 = ctx.Products.Add(new Product()
            {
                Size = "s",
                Colour = "Denim",
                Brand = "DIESEL",
                Type = Type.Jeans,
                Price = 35
            }).Entity;

            var prod12 = ctx.Products.Add(new Product()
            {
                Size = "m",
                Colour = "Denim",
                Brand = "Diesel",
                Type = Type.Jeans,
                Price =35
            }).Entity;

            var prod13 = ctx.Products.Add(new Product()
            {
                Size = "l",
                Colour = "Denim",
                Brand = "EA",
                Type = Type.Jeans,
                Price = 35
            }).Entity;

            var prod14 = ctx.Products.Add(new Product()
            {
                Size = "s",
                Colour = "White",
                Brand = "Lacoste",
                Type = Type.Shirt,
                Price = 40
            }).Entity;

             var prod15 = ctx.Products.Add(new Product()
            {
                Size = "m",
                Colour = "White",
                Brand = "Lacoste",
                Type = Type.Shirt,
                Price = 40
            }).Entity;

             var prod16 = ctx.Products.Add(new Product()
             {
                 Size = "l",
                 Colour = "White",
                 Brand = "Lacoste",
                 Type = Type.Shirt,
                 Price = 40
             }).Entity;

            List<Product> list1 = new List<Product>()
            {
                prod1,prod2,prod3,prod4,prod5,prod7,prod8,prod9,prod10,prod11,prod12,prod13,prod14,prod16,
                prod15
            };

             var order1 = ctx.Orders.Add(new Order()
             {
                 OrderDate = DateTime.Now,
                 DeliveryDate = DateTime.Now,
                 Address = "UK",
                 Customers = cust1,
                 Products = list1,
             }).Entity;

             List<Product> list2 = new List<Product>()
             {
                 prod1,prod2,prod3,prod4,prod5,prod7,prod8,prod9,prod10,prod11,prod12,prod13,prod14,prod16,
                 prod15
             };
            var order2 = ctx.Orders.Add(new Order()
             {
                 OrderDate = DateTime.Now,
                 DeliveryDate = DateTime.Now,
                 Address = "UK",
                 Customers = cust2,
                 Products = list2,
             }).Entity;

            List<Product> list3 = new List<Product>()
            {
                prod1,prod2,prod3,prod4,prod5,prod7,prod8,prod9,prod10,prod11,prod12,prod13,prod14,prod16,
                prod15
            };
            var order3 = ctx.Orders.Add(new Order()
             {
                 OrderDate = DateTime.Now,
                 DeliveryDate = DateTime.Now,
                 Address = "UK",
                 Customers = cust3,
                 Products = list3,
             }).Entity;

            List<Product> list4 = new List<Product>()
            {
                prod1,prod2,prod3,prod4,prod5,prod7,prod8,prod9,prod10,prod11,prod12,prod13,prod14,prod16,
                prod15
            };

            var order4 = ctx.Orders.Add(new Order()
             {
                 OrderDate = DateTime.Now,
                 DeliveryDate = DateTime.Now,
                 Address = "Denmark",
                 Customers = cust1,
                 Products = list4,
             }).Entity;

            List<Product> list5 = new List<Product>()
            {
                prod1,prod2,prod3,prod4,prod5,prod7,prod8,prod9,prod10,prod11,prod12,prod13,prod14,prod16,
                prod15
            };
            var order5 = ctx.Orders.Add(new Order()
             {
                 OrderDate = DateTime.Now,
                 DeliveryDate = DateTime.Now,
                 Address = "Denmark",
                 Customers = cust2,
                 Products = list5,
             }).Entity;

            List<Product> list6 = new List<Product>()
            {
                prod1,prod2,prod3,prod4,prod5,prod7,prod8,prod9,prod10,prod11,prod12,prod13,prod14,prod16,
                prod15
            };

            var order6 = ctx.Orders.Add(new Order()
             {
                 OrderDate = DateTime.Now,
                 DeliveryDate = DateTime.Now,
                 Address = "Denmark",
                 Customers = cust3,
                 Products = list6,
             }).Entity;
             

            ctx.SaveChanges();
        }
    }
}
