using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.API.src.Commands.Handlers;
using User.API.src.Commands.Requests;
using User.API.src.Queries.Handlers;
using User.API.src.Queries.Requests;

namespace User.API.src.Controllers
{
    [ApiController]
    [Route("api/Users")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Criar novo Usuario
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="request">Dados do Usuario</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/Users
        ///     {
        ///         "nome": "Gustavo Boaz",
        ///         "sobrenome": "De Moura Souza",
        ///         "email": "gustavo@domain.com",
        ///         "dataNascimento": "1991-03-09T01:30:47.650Z",
        ///         "escolaridade": "Superior"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Usuario Criado</response>
        /// <response code="400">Erro na requisição</response>
        /// <response code="500">Erro no servidor</response>
        [HttpPost]
        public async Task<ActionResult> Create([FromServices] IUserCommands handler, [FromBody] CreateUserRequest request)
        {
            try
            {
                return Ok(await handler.HandlerAsync(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Pegar tema pelo Id
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="id">Id do usuario</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna o usuario</response>
        /// <response code="404">Id não existente</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> Read([FromServices] IUserQueries handler, [FromRoute] string id)
        {
            try
            {
                return Ok(await handler.HandlerAsync(new GetByIdRequest(id)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar um Usuario
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="request">Dados do Usuario</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/Users
        ///     {
        ///         "id": "fdc0b32e-a21f-4fea-8656-7e8e2b7d7a51",    
        ///         "nome": "Gustavo Boaz",
        ///         "sobrenome": "De Moura Souza",
        ///         "email": "gustavo@domain.com",
        ///         "dataNascimento": "1991-03-09T01:30:47.650Z",
        ///         "escolaridade": "Superior"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Usuario Alterado</response>
        /// <response code="400">Erro na requisição</response>
        /// <response code="500">Erro no servidor</response>
        [HttpPut]
        public async Task<ActionResult> Update([FromServices] IUserCommands handler, [FromBody] UpdateUserRequest request)
        {
            try
            {
                return Ok(await handler.HandlerAsync(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletar usuario pelo Id
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="id">Id do usuario</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Usuario deletado</response>
        /// <response code="404">Id não existe</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromServices] IUserCommands handler, [FromRoute] string id)
        {
            try
            {
                return Ok(await handler.HandlerAsync(new DeleteUserRequest(id)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Pegar todos temas
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Lista de usuarios</response>
        [HttpGet("all")]
        public async Task<ActionResult> GetAll([FromServices] IUserQueries handler)
        {
            var content = await handler.HandlerAsync();

            return Ok(content.GetUsers());
        }
    }
}