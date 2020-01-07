using Meta.Application.Commands;
using Meta.Application.Contracts;
using Meta.Presentation.API.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Projeto.Presentation.Controllers
{
    [Route("api/Contato")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoApplicationService _contatoApplicationService;
        public ContatoController(IContatoApplicationService ContatoApplicationService)
        {
            this._contatoApplicationService = ContatoApplicationService;
        }

        [HttpPost]
        public IActionResult Post(ContatoCreateCommand command)
        {
            if (!ModelState.IsValid) return StatusCode(400, ModelStateValidation.GetErrors(ModelState));

            try
            {
                _contatoApplicationService.Create(command);

                return StatusCode(201,"O contato foi cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ContatoUpdateCommand command)
        {
            if (!ModelState.IsValid) return StatusCode(400, ModelStateValidation.GetErrors(ModelState));

            try
            {
                _contatoApplicationService.Update(command);
                return StatusCode(200, "O contato foi atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idContato}")]
        public IActionResult Delete(string idContato)
        {
            if (!ModelState.IsValid) return StatusCode(400, ModelStateValidation.GetErrors(ModelState));

            try
            {
                var command = new ContatoDeleteCommand { Id = idContato };
                _contatoApplicationService.Delete(command);
                return Ok("O contato foi excluido com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GET(int page = 1, int size = 10)
        {
           
            try
            {
                int totalPaginas = (int)Math.Ceiling(_contatoApplicationService.Count() / Convert.ToDecimal(size));

                if(page < totalPaginas) Response.Headers.Add("X-Pages-NextPages", Url.Link("X-Pages-NextPages", new { page = page + 1, size }));
                
                Response.Headers.Add("X-Pages-TotalPages", totalPaginas.ToString());

                return Ok(_contatoApplicationService.GetAll().Skip(size * (page - 1)).Take(size));

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idContato}")]
        public IActionResult GET(string idContato)
        {
            if (!ModelState.IsValid) return StatusCode(400, ModelStateValidation.GetErrors(ModelState));

            try
            {
                return Ok(_contatoApplicationService.GetById(idContato));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
