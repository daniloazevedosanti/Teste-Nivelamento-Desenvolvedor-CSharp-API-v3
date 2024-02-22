using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Response;
using Questao5.Application.Repositories;
using Questao5.Domain.Entities;

namespace Questao5.Application.Handler
{
    public class InserirMovimentoHandler : IRequestHandler<InserirMovimentoRequest, InserirMovimentoResponse>
    {
        private readonly IMovimentoRepository Movimentorepository;
        private readonly IContaCorrenteRepository ContaCorrenteRepository;
        private readonly IIdempotenciaRepository IdempotenciaRepository;

        public InserirMovimentoHandler(IMovimentoRepository movimentorepo, IContaCorrenteRepository contaCorrenterepo, IIdempotenciaRepository idempotenciarepo)
        {
            Movimentorepository = movimentorepo;
            ContaCorrenteRepository = contaCorrenterepo;
            IdempotenciaRepository = idempotenciarepo;
        }

        public Task<InserirMovimentoResponse> Handle(InserirMovimentoRequest request, CancellationToken cancellationToken)
        {
            var idempotencia = IdempotenciaRepository.BuscaIdempotenciaPeloId(request.IdIdempotente);

            if (idempotencia == null)
            {
                idempotencia = new Idempotencia(request.ToString());
                IdempotenciaRepository.InserirIdempotencia(idempotencia);                
            }
            else if (!string.IsNullOrEmpty(idempotencia.Retorno))
            {
                return Task.FromResult(idempotencia.Retorno.Contains("Erro: ") ? new InserirMovimentoResponse(Guid.Empty, idempotencia.Retorno) : new InserirMovimentoResponse(Guid.Parse(idempotencia.Retorno), ""));
            }

            var contacorrente = ContaCorrenteRepository.BuscaContaCorrentePeloId(request.Idcontacorrente);

            string msgerro = "";

            if (!contacorrente.Validar( ref msgerro))
            {
                idempotencia.Retorno = msgerro;
                IdempotenciaRepository.AtualizarIdempotencia(idempotencia);
                return Task.FromResult(new InserirMovimentoResponse(Guid.Empty, msgerro));
            }

            var movimento = new Movimento(contacorrente, request.Tipo, request.Valor);

            if (!movimento.Validar(ref msgerro))
            {
                idempotencia.Retorno = msgerro;
                IdempotenciaRepository.AtualizarIdempotencia(idempotencia);
                return Task.FromResult(new InserirMovimentoResponse(Guid.Empty, msgerro));
            }

            Guid idmov;
            try
            {
                idmov = Movimentorepository.InserirMovimento(movimento);                
            }
            catch (Exception ex)
            {
                return Task.FromResult(new InserirMovimentoResponse(Guid.Empty, ex.Message));
            }

            var retorno = new InserirMovimentoResponse(idmov, "");
            idempotencia.Retorno = idmov.ToString();
            IdempotenciaRepository.AtualizarIdempotencia(idempotencia);            

            return Task.FromResult(retorno);
        }
    }
}