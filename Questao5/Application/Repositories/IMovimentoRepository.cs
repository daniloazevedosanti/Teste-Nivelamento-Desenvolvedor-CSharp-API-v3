using Questao5.Domain.Entities;

namespace Questao5.Application.Repositories
{
    public interface IMovimentoRepository
    {
        Guid InserirMovimento(Movimento movimento);
    }
}