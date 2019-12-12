using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity;
using TheRange.Core.Helper;

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
                PhoneNumber = 3456789,
                Email = "abc@live.co.uk",
            });

            var cust2 = ctx.Customers.Add(new Customer()
            {

                FirstName = "Jack",
                LastName = "Taylor",
                Address = "romastrasse 55",
                PhoneNumber = 1235698,
                Email = "xyz@live.co.uk"

            });
            var cust3 = ctx.Customers.Add(new Customer()
            {
                FirstName = "Zack",
                LastName = "Cook",
                Address = "windsor 214",
                PhoneNumber = 254897,
                Email = "smt@live.co.uk",
            });

        }
    }
}
