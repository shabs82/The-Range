using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.DomainService;
using TheRange.Core.Entity;

namespace TheRange.Infrastructure.SQL.Data
{
    public class UserRepository : IUserRepository
    {
        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }

        public User ValidateUser(LoginInputModel loginInputModel)
        {
            throw new NotImplementedException();
        }
    }
}
