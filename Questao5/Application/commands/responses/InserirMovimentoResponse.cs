namespace Questao5.Application.Commands.Response
{
    public class InserirMovimentoResponse
    {
        public InserirMovimentoResponse(Guid id, string msg)
        {
            Idmovimento = id;
            MensagemErro = msg;
        }

        public Guid Idmovimento { get; set; }
        public string? MensagemErro { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(MensagemErro) ? Idmovimento.ToString() : "Erro: " + MensagemErro;
        }
    }
}