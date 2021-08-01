using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Input;
using TEST_DEV_JRL_20210731.DataAccess.Model;

namespace TEST_DEV_JRL_20210731.Services.Interfaces
{
    public interface IPersonProcessService
    {
        TbPersonasFisica Create(PersonCreateDtoInput person);
        TbPersonasFisica Update(PersonUpdateDtoInput person);
        IEnumerable<TbPersonasFisica> Get();
        TbPersonasFisica GetById(int id);
        bool Delete(int id);
        bool ActiveInactive(int id);
    }
}
