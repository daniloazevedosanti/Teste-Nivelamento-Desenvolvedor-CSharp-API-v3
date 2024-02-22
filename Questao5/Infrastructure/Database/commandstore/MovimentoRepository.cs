using Microsoft.Data.Sqlite;
using Questao5.Application.Repositories;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore.Queries;
using Questao5.Infrastructure.Sqlite;
using Dapper;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public MovimentoRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public Guid InserirMovimento(Movimento movimento)
        {
            using var connection = new SqliteConnection(_databaseConfig.Name);
            var query = new MovimentoQuery().InserirMovimentoQuery(movimento);

            try
            {
                using (connection)
                {
                    connection.Execute(query.Query, query.Parameters);
                }
            }
            catch
            {
                new Exception("Erro ao inserir movimento.");
            }            

            return movimento.Idmovimento;
        }
    }
}