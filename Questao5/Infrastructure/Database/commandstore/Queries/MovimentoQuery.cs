using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.Shared;

namespace Questao5.Infrastructure.Database.CommandStore.Queries
{
    public class MovimentoQuery : BaseQuery
    {
        public MovimentoQuery() { }

        public QueryModel InserirMovimentoQuery(Movimento movimento)
        {
            this.Table = Maps.BuscaNomeTabelaMovimento();
            this.Query = $@"
                INSERT INTO {this.Table}
                VALUES (
                    @idmovimento,
                    @idcontacorrente,
                    @datamovimento,
                    @tipomovimento,
                    @valor                    
                )
            ";

            this.Parametros = new
            {
                idmovimento = movimento.Idmovimento,
                idcontacorrente = movimento.Contacorrente.Idcontacorrente,
                datamovimento = movimento.Datamovimento,
                tipomovimento = movimento.Tipomovimento,
                valor = movimento.Valor
            };

            return new QueryModel(this.Query, this.Parametros);
        }
    }
}