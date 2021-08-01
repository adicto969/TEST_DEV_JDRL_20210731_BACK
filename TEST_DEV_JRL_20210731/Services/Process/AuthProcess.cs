using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_JRL_20210731.DataAccess;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Input;
using TEST_DEV_JRL_20210731.DataAccess.Exceptions;
using TEST_DEV_JRL_20210731.DataAccess.Model;
using TEST_DEV_JRL_20210731.Services.Interfaces;
using TEST_DEV_JRL_20210731.Utils;

namespace TEST_DEV_JRL_20210731.Services.Process
{
    public class AuthProcess : IUserProcessService
    {
        private readonly TESTJDRLContext _context;
        public AuthProcess(TESTJDRLContext context)
        {
            this._context = context;
        }

        public User Login(Login login)
        {
            User user = this._context.User.Where(user => user.Email.Equals(login.Email) && user.Password.Equals(EncriptMD5.Hash(login.Password))).FirstOrDefault();

            if (user is null)
            {
                throw new SystemValidationException("Invalid Credencials");
            }

            return user;
        }

        public User Create(User user)
        {
            var existEmail = this._context.User.Where(userfilter => userfilter.Email.Equals(user.Email)).FirstOrDefault();

            if (existEmail != null)
            {
                throw new SystemValidationException("The email ready in use");
            }

            user.Password = EncriptMD5.Hash(user.Password);
            this._context.User.Add(user);
            this._context.SaveChanges();

            return user;
        }
    }
}
