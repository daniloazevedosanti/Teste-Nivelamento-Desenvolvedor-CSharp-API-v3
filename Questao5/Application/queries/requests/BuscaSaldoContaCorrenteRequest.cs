using MediatR;
using Questao5.Application.Commands.Response;
using Questao5.Application.Queries.Response;

namespace Questao5.Application.Queries.Requests
{
    public class BuscaSaldoContaCorrenteRequest : IRequest<BuscaSaldoContaCorrenteResponse>
    {
        public Guid Idcontacorrente { get; set; }
    }
}