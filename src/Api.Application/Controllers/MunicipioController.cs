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
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioService _service;
        public MunicipioController(IMunicipioService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult> listaUfs()
        {
            try
            {
                var ufs = await _service.GetAll();

                if (ufs != null)
                    return Ok(ufs);
                else
                    return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(MunicipioDtoCreate entity)
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
