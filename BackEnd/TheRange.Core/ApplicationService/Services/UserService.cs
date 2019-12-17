using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.DomainService;
using TheRange.Core.Entity;
using TheRange.Core.Helper;

namespace TheRange.Core.ApplicationService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationHelper _authenticationHelper;


        public UserService(IUserRepository userRepository, IAuthenticationHelper authenticationHelper)
        {
            _userRepository = userRepository;
            _authenticationHelper = authenticationHelper;
        }

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

        public User ValidateUser(LoginInputModel loginInput)
        {
            if (loginInput == null)
            {
                throw new ArgumentNullException("LoginInput cannot be null");
            }
            else if (string.IsNullOrEmpty(loginInput.Username))
            {
                throw new ArgumentException("You need to specify a Username for the LoginInput");
            }
            else if (string.IsNullOrEmpty(loginInput.Password))
            {
                throw new ArgumentException("You need to specify a Password for the LoginInput");
            }

            User user = _userRepository.ReadById(loginInput.Id);
            if (_authenticationHelper.VerifyPasswordHash(loginInput.Password, user.PasswordHash, user.PasswordSalt) == false)
            {
                throw new ArgumentException("The Password does not match the User's StoredPassword");
            }
            return user;
        }
    }
}
