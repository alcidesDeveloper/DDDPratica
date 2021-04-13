using Api.Domain.Dtos.Address;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Address;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ICepService _service;
        public CepController(ICepService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult> listaCeps()
        {
            try
            {
                var ceps = await _service.GetAll();

                if (ceps != null)
                    return Ok(ceps);
                else
                    return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(CepDtoCreate entity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var user = await _service.Post(entity);

                if (user != null)
                {

                    return Created("tst",true);
                }

                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
