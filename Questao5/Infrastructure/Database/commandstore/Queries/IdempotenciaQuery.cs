using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.Shared;

namespace Questao5.Infrastructure.Database.CommandStore.Queries
{
    public class IdempotenciaQuery : BaseQuery
    {
        public IdempotenciaQuery() { }

        public QueryModel InserirIdempotenciaQuery(Idempotencia idempotencia)
        {
            this.Table = Maps.BuscaNomeTabelaIdempontecia();
            this.Query = $@"
                INSERT INTO {this.Table}
                VALUES (
                    @ididempotencia,
                    @requisicao,
                    @resultado                    
                )
            ";

            this.Parametros = new
            {
                ididempotencia = idempotencia.Ididempotencia,
                requisicao = idempotencia.Requisicao,
                resultado = idempotencia.Retorno
            };

            return new QueryModel(this.Query, this.Parametros);
        }

        public QueryModel AtualizarIdempotenciaQuery(Idempotencia idempotencia)
        {
            this.Table = Maps.BuscaNomeTabelaIdempontecia();
            this.Query = $@"
                UPDATE {this.Table}
                SET                    
                    REQUISICAO = @requisicao,
                    RESULTADO = @resultado
                WHERE
                    IDIDEMPOTENCIA = @idempotencia
            ";

            this.Parametros = new
            {
                ididempotencia = idempotencia.Ididempotencia,
                requisicao = idempotencia.Requisicao,
                resultado = idempotencia.Retorno
            };

            return new QueryModel(this.Query, this.Parametros);
        }

        public QueryModel BuscaIdempotenciaPeloId(Guid id)
        {
            this.Table = Maps.BuscaNomeTabelaIdempontecia();
            this.Query = $@"
                SELECT
                    IDIDEMPOTENCIA,
                    REQUISICAO,
                    RESULTADO
                FROM {this.Table}                
                WHERE
                    IDIDEMPOTENCIA = @idempotencia
            ";

            this.Parametros = new
            {
                ididempotencia = id                
            };

            return new QueryModel(this.Query, this.Parametros);
        }
    }
}