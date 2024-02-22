using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[Movimento]")]
    public class MovimentoController : ControllerBase
    {
        [HttpPost]
        [Route("/Adicionar")]
        public IActionResult InserirMovimento(
                   [FromServices] IMediator mediator,
                   [FromBody] InserirMovimentoRequest command
               )
        {
            var response = mediator.Send(command);

            if (string.IsNullOrEmpty(response.Result.MensagemErro))
                return Ok(response.Result.Idmovimento);
            else
                return BadRequest(response.Result.MensagemErro);
        }
    }
}