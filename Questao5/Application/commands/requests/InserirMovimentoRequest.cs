using MediatR;
using Questao5.Application.Commands.Response;

namespace Questao5.Application.Commands.Requests
{
    public class InserirMovimentoRequest : IRequest<InserirMovimentoResponse>
    {
        public Guid IdIdempotente { get; set; }
        public Guid Idcontacorrente { get; set; }
        public decimal Valor { get; set; }
        public char Tipo { get; set; }

        public override string ToString()
        {
            var request = $@"
                Ididempotente: {IdIdempotente.ToString()},
                Idcontacorrente: {Idcontacorrente.ToString()},
                Valor: {Valor.ToString()},
                Tipomovimento: {Tipo.ToString()}
            ";
            return request;
        }
    }
}