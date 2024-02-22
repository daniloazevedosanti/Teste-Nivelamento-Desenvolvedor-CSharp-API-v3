using Questao5.Infrastructure.Database.Shared;

namespace Questao5.Infrastructure.Database.QueryStore.Queries
{
    public class ContaCorrenteQueries : BaseQuery
    {
        public QueryModel BuscaContaCorrentePeloId(Guid id)
        {
            this.Table = Maps.BuscaNomeTabelaContaCorrente();

            this.Query = $@"
                SELECT
                    IDCONTACORRENTE,
                    NUMERO,
                    ATIVO
                FROM {this.Table}
                WHERE IDCONTACORRENTE = @idconta
            ";

            this.Parametros = new
            {
                idconta = id
            };

            return new QueryModel(this.Query, this.Parametros);
        }

        public QueryModel BuscaSaldoContaCorrentePeloId(Guid id)
        {
            this.Table = Maps.BuscaNomeTabelaContaCorrente();

            this.Query = $@"
                SELECT                    
                    SUM(
                        CASE
                            WHEN TIPOMOVIMENTO = 'C' THEN VALOR
                            ELSE (-1) * VALOR
                        END
                    ) SALDO
                FROM {this.Table}                    
                WHERE IDCONTACORRENTE = @idconta                
            ";

            this.Parametros = new
            {
                idconta = id
            };

            return new QueryModel(this.Query, this.Parametros);
        }
    }
}