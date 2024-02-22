using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Response;
using Questao5.Application.Repositories;
using Questao5.Domain.Entities;

namespace Questao5.Application.Handler
{
    public class BuscaSaldoContaCorrenteHandler : IRequestHandler<BuscaSaldoContaCorrenteRequest, BuscaSaldoContaCorrenteResponse>
    {
        private readonly IContaCorrenteRepository ContaCorrenteRepository;

        public BuscaSaldoContaCorrenteHandler(IContaCorrenteRepository contacorrenterepo)
        {
            ContaCorrenteRepository = contacorrenterepo;
        }

        public Task<BuscaSaldoContaCorrenteResponse> Handle(BuscaSaldoContaCorrenteRequest request, CancellationToken cancellationToken)
        {
            ContaCorrente contacorrente;

            try
            {
                contacorrente = ContaCorrenteRepository.BuscaContaCorrentePeloId(request.Idcontacorrente);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new BuscaSaldoContaCorrenteResponse(ex.Message));
            }

            string msgerro = "";

            if (!contacorrente.Validar(ref msgerro))
            {                
                return Task.FromResult(new BuscaSaldoContaCorrenteResponse(contacorrente.Numero, contacorrente.Nome, 0, msgerro));
            }

            try
            {
                var saldo = ContaCorrenteRepository.BuscaSaldoPeloId(request.Idcontacorrente);
                return Task.FromResult(new BuscaSaldoContaCorrenteResponse(contacorrente.Numero, contacorrente.Nome, saldo, ""));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new BuscaSaldoContaCorrenteResponse(ex.Message));
            }
        }
    }
}