using Questao5.Domain.Entities;

namespace Questao5.Application.Repositories
{
    public interface IContaCorrenteRepository
    {
        ContaCorrente BuscaContaCorrentePeloId(Guid id);

        decimal BuscaSaldoPeloId(Guid id);
    }
}