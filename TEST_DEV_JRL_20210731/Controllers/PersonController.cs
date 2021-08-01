using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_DEV_JRL_20210731.Services.Interfaces;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Input;

namespace TEST_DEV_JRL_20210731.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonProcessService _personProcess;

        public PersonController(IPersonProcessService personProcess)
        {
            this._personProcess = personProcess;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._personProcess.Get());
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(this._personProcess.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(PersonCreateDtoInput person)
        {
            if (ModelState.IsValid)
            {
                var idUser = int.Parse(HttpContext.User.FindFirst("UserId").Value);
                person.UsuarioAgrega = idUser;
                return Ok(this._personProcess.Create(person));
            }

            return BadRequest();
        }

        [HttpPut, Route("{id}")]
        public IActionResult Update(int id, PersonUpdateDtoInput person)
        {
            var userHttpContext = HttpContext.User;
            person.IdPersonaFisica = id;

            if (ModelState.IsValid)
            {
                return Ok(this._personProcess.Update(person));
            }

            return BadRequest();
        }

        [HttpDelete, Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(this._personProcess.Delete(id));
        }

        [HttpPut, Route("{id}/Active-Inactive")]
        public IActionResult ActiveInactive(int id)
        {
            return Ok(this._personProcess.ActiveInactive(id));
        }

    }
}
