using Questao5.Domain.Entities;

namespace Questao5.Application.Repositories
{
    public interface IIdempotenciaRepository
    {
        Idempotencia BuscaIdempotenciaPeloId(Guid id);

        bool InserirIdempotencia(Idempotencia idempotencia);

        bool AtualizarIdempotencia(Idempotencia idempotencia);
    }
}