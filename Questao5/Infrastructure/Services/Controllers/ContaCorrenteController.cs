using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("ContaCorrente")]
    public class ContaCorrenteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult BuscaSaldo(
                   [FromServices] IMediator mediator,
                   [FromQuery] BuscaSaldoContaCorrenteRequest command
               )
        {
            var response = mediator.Send(command);

            if (string.IsNullOrEmpty(response.Result.Mensagemerro))
                return Ok(response.Result);
            else
                return BadRequest(response.Result.Mensagemerro);
        }
    }
}