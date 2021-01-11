using Domain.Entities;
using Domain.Services.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IUserService service)
        {
            //IActionResult é uma classe que pode trabalhar com diversos tipo de results, como por exemplo o JSON
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - soliciatação inválida <- releembrando
                //ModelState: Uma validação efetuada por "baixo dos panos"
                //Exemplo: Se voce mandar uma string e o método esperar int, será inválido e cairá neste 
            }
            try
            {
                return Ok(await service.GetAll());
            }
            catch (ArgumentException e) //ArgumentException Melhor para tratar erros de controller
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); //setando a mensagem para um código de internal error: 500 (normalmente)

            }
        }
        [HttpGet]
        [Route("{id}", Name = "GetWithId")] //Name = "GetWithId": É somente para referenciar internamente dentro da Controller 
        public async Task<IActionResult> Get([FromServices] IUserService service, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - soliciatação inválida <- releembrando
            }
            try
            {
                return Ok(await service.Get(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IUserService service, [FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - soliciatação inválida <- releembrando

            }

            try
            {
                var result = await service.Post(user);

                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.id })), result); //httpCode: 201
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut("{id")]
        public async Task<IActionResult> Put([FromServices] IUserService service, UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - soliciatação inválida <- releembrando
            }
            try
            {
                var result = await service.Put(user);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

       [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, [FromServices] IUserService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - soliciatação inválida <- releembrando
            }
            try
            {
                return Ok(await service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

