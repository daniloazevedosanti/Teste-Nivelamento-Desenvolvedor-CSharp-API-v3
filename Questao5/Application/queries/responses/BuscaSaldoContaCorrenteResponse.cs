namespace Questao5.Application.Queries.Response
{
    public class BuscaSaldoContaCorrenteResponse
    {
        public BuscaSaldoContaCorrenteResponse(int numero, string nome, decimal saldo, string msgerro)
        {
            Numero = numero;
            Nome = nome;
            Saldo = saldo;
            Mensagemerro = msgerro;
        }

        public BuscaSaldoContaCorrenteResponse(string msgerro)
        {
            Mensagemerro = msgerro;
        }

        public int Numero { get; set; }
        public string? Nome { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public decimal Saldo { get; set; }
        public string Mensagemerro { get; set; }
    }
}