using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Input;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Output;
using TEST_DEV_JRL_20210731.DataAccess.Model;
using TEST_DEV_JRL_20210731.Services.Interfaces;
using TEST_DEV_JRL_20210731.Services.Process;

namespace TEST_DEV_JRL_20210731.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserProcessService _userProcessService;
        IConfiguration _configuration { get; }

        public UserController(IUserProcessService userProcessService, IConfiguration configuration)
        {
            this._userProcessService = userProcessService;
            this._configuration = configuration;
        }

        [HttpPost, Route("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            if (ModelState.IsValid)
            {
                User user = this._userProcessService.Login(login);

                return Ok(new TokenResponse { 
                    Token = JwtProcessService.GenerateToken(this._configuration, user)
                });
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                return Ok(this._userProcessService.Create(user));
            }

            return BadRequest();
        }
    }
}
