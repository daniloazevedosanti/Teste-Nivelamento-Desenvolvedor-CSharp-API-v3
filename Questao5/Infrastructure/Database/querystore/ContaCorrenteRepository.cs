using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.Repositories;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore.Queries;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.QueryStore
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public ContaCorrenteRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public ContaCorrente BuscaContaCorrentePeloId(Guid id)
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);
            var query = new ContaCorrenteQueries().BuscaContaCorrentePeloId(id);            

            try
            {
                using (connection)
                {
                    return connection.QueryFirstOrDefault<ContaCorrente>(query.Query, query.Parameters) as ContaCorrente;
                }
            }
            catch
            {
                throw new Exception("Erro ao buscar conta corrente.");
            }
        }

        public decimal BuscaSaldoPeloId(Guid id)
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);
            var query = new ContaCorrenteQueries().BuscaSaldoContaCorrentePeloId(id);

            try
            {
                using (connection)
                {
                    return (decimal)connection.QueryFirstOrDefault(query.Query, query.Parameters);
                }
            }
            catch
            {
                throw new Exception("Erro ao buscar saldo conta corrente.");
            }
        }
    }
}