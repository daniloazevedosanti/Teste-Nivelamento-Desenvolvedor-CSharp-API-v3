using Microsoft.Data.Sqlite;
using Questao5.Application.Repositories;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore.Queries;
using Questao5.Infrastructure.Sqlite;
using Dapper;
using Questao5.Infrastructure.Database.QueryStore.Queries;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public class IdempotenciaRepository : IIdempotenciaRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public IdempotenciaRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public bool AtualizarIdempotencia(Idempotencia idempotencia)
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);
            var query = new IdempotenciaQuery().AtualizarIdempotenciaQuery(idempotencia);

            try
            {
                using (connection)
                {
                    connection.Execute(query.Query, query.Parameters);
                }
            }
            catch
            {
                new Exception("Erro ao atualizar idempotencia.");
            }

            return true;
        }

        public Idempotencia BuscaIdempotenciaPeloId(Guid id)
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);
            var query = new IdempotenciaQuery().BuscaIdempotenciaPeloId(id);

            try
            {
                using (connection)
                {
                    return connection.QueryFirstOrDefault<Idempotencia>(query.Query, query.Parameters) as Idempotencia;
                }
            }
            catch
            {
                throw new Exception("Erro ao buscar idempotencia.");
            }
        }

        public bool InserirIdempotencia(Idempotencia idempotencia)
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);
            var query = new IdempotenciaQuery().InserirIdempotenciaQuery(idempotencia);

            try
            {
                using (connection)
                {
                    connection.Execute(query.Query, query.Parameters);
                }
            }
            catch
            {
                new Exception("Erro ao inserir idempotencia.");
            }

            return true;
        }        
    }
}