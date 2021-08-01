using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Input;
using TEST_DEV_JRL_20210731.DataAccess.Exceptions;
using TEST_DEV_JRL_20210731.DataAccess.Model;
using TEST_DEV_JRL_20210731.Services.Interfaces;

namespace TEST_DEV_JRL_20210731.Services.Process
{
    public class PersonProcess : IPersonProcessService
    {
        private readonly TESTJDRLContext _context;

        public PersonProcess(TESTJDRLContext context)
        {
            this._context = context;
        }

        public bool ActiveInactive(int id)
        {
            var person = this._context.TbPersonasFisicas.Where(person => person.IdPersonaFisica == id).FirstOrDefault();

            if (person is null)
            {
                throw new SystemValidationException("Person Not Found");
            }

            person.FechaActualizacion = DateTime.Now;
            person.Activo = !person.Activo;
            this._context.TbPersonasFisicas.Update(person);
            this._context.SaveChanges();

            return true;
        }

        public TbPersonasFisica Create(PersonCreateDtoInput person)
        {

            var existRfc = this._context.TbPersonasFisicas.Where(personquery => personquery.Rfc.ToLower().Equals(person.Rfc.ToLower())).FirstOrDefault();

            if (existRfc != null)
            {
                throw new SystemValidationException("RFC Ready Exist");
            }

            TbPersonasFisica newPerson = new TbPersonasFisica();
            newPerson.Activo = true;
            newPerson.ApellidoMaterno = person.ApellidoMaterno;
            newPerson.ApellidoPaterno = person.ApellidoPaterno;
            newPerson.FechaActualizacion = DateTime.Now;
            newPerson.FechaNacimiento = person.FechaNacimiento;
            newPerson.FechaRegistro = DateTime.Now;
            newPerson.Nombre = person.Nombre;
            newPerson.Rfc = person.Rfc;
            newPerson.UsuarioAgrega = person.UsuarioAgrega;

            this._context.TbPersonasFisicas.Add(newPerson);
            this._context.SaveChanges();

            return newPerson;
        }

        public bool Delete(int id)
        {
            var person = this._context.TbPersonasFisicas.Where(person => person.IdPersonaFisica == id).FirstOrDefault();

            if (person is null)
            {
                throw new SystemValidationException("Person Not Found");
            }

            this._context.TbPersonasFisicas.Remove(person);
            this._context.SaveChanges();

            return true;
        }

        public IEnumerable<TbPersonasFisica> Get()
        {
            return this._context.TbPersonasFisicas.ToList();
        }

        public TbPersonasFisica GetById(int id)
        {
            var person = this._context.TbPersonasFisicas.Where(person => person.IdPersonaFisica == id).FirstOrDefault();

            if (person is null)
            {
                throw new SystemValidationException("Person Not Found");
            }

            return person;
        }

        public TbPersonasFisica Update(PersonUpdateDtoInput person)
        {
            var personresult = this._context.TbPersonasFisicas.Where(personquery => personquery.IdPersonaFisica == person.IdPersonaFisica).FirstOrDefault();

            if (personresult is null)
            {
                throw new SystemValidationException("Person Not Found");
            }

            var existRfc = this._context.TbPersonasFisicas.Where(personquery => personquery.IdPersonaFisica != personresult.IdPersonaFisica && personquery.Rfc.ToLower().Equals(person.Rfc.ToLower())).FirstOrDefault();

            if (existRfc != null)
            {
                throw new SystemValidationException("RFC Ready Exist");
            }

            if (person.Nombre != string.Empty)
            {
                personresult.Nombre = person.Nombre;
            }

            if (person.ApellidoPaterno != string.Empty)
            {
                personresult.ApellidoPaterno = person.ApellidoPaterno;
            }

            if (person.ApellidoMaterno != string.Empty)
            {
                personresult.ApellidoMaterno = person.ApellidoMaterno;
            }

            if (person.Rfc != string.Empty)
            {
                personresult.Rfc = person.Rfc;
            }

            if (person.FechaNacimiento != null)
            {
                personresult.FechaNacimiento = person.FechaNacimiento;
            }

            personresult.FechaActualizacion = DateTime.Now;

            this._context.TbPersonasFisicas.Update(personresult);
            this._context.SaveChanges();

            return personresult;
        }
    }
}
