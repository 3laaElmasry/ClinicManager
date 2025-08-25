
using ClinicManager.Core.Common;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        [HttpPost("PatientRegister")]
        public ActionResult<Result<ApplicationUser>> PatientRegisterAsync([FromBody] RegisterPatient model)
        {
            return Ok();
        }


    }
}
