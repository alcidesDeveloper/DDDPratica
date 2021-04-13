using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var users = await _service.GetAll();

                return Ok(users);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> GetUserById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var user = await _service.Get(id);

                if(user == null)
                   return NotFound();
                
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] UserDtoCreate userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var user = await _service.Post(userDto);

                if (user != null)
                {

                    return Created(new Uri(Url.Link("GetWithId", new { id = user.Id })), user);
                }

                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> UpdateData([FromBody] UserDtoUpdate userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var created = await _service.Put(userDto);

                if (created != null)
                {

                    return Ok(created);
                }

                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                bool created = await _service.Delete(id);

                if (created)
                {

                    return Ok(created);
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
