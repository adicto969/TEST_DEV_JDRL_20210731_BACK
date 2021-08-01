using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_JRL_20210731.DataAccess;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Input;
using TEST_DEV_JRL_20210731.DataAccess.Model;

namespace TEST_DEV_JRL_20210731.Services.Interfaces
{
    public interface IUserProcessService
    {
        User Login(Login login);
        User Create(User user);
    }
}
