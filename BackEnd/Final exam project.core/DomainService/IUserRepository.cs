using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity;

namespace TheRange.Core.DomainService
{
    public interface IUserRepository
    {
        User Create(User user);
        User Update(User user);
        User Delete(int id);
        User ReadById(int id);
        User ValidateUser(LoginInputModel loginInputModel);
    }
}
