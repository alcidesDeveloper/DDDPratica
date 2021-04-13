using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
      
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid || loginDto == null) 
                return BadRequest();

            try
            {
                var user = await service.FindByLogin(loginDto);

                if (user != null)
                    return Ok(user);
                else
                    return NotFound();
            }
            catch(ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    
    }
}
