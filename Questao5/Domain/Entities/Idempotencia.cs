namespace Questao5.Domain.Entities
{
    public class Idempotencia
    {
        public Idempotencia(string req)
        {
            Ididempotencia = Guid.NewGuid();
            Requisicao = req;
        }

        public Idempotencia(string req, string ret)
        {
            Ididempotencia = Guid.NewGuid();
            Requisicao = req;
            Retorno = ret;
        }

        public Guid Ididempotencia { get; }        
        public string? Requisicao { get; set; }
        public string? Retorno { get; set; }
    }
}