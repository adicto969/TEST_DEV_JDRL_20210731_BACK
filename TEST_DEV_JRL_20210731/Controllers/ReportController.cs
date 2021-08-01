using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Input;
using TEST_DEV_JRL_20210731.Services.Interfaces;

namespace TEST_DEV_JRL_20210731.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class ReportController : ControllerBase
    {
        IReportProcessService _reportProcessService;
        IConfiguration _configuration { get; }

        public ReportController(IReportProcessService reportProcessService, IConfiguration configuration)
        {
            this._reportProcessService = reportProcessService;
            this._configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int? page, int? count)
        {
            return Ok(this._reportProcessService.GetReport(page ?? 1, count ?? 20));
        }
    }
}
