namespace Questao5.Infrastructure.Database.Shared
{
    public static class Maps
    {
        public static string BuscaNomeTabelaMovimento()
        {
            return "[movimento]";
        }

        public static string BuscaNomeTabelaContaCorrente()
        {
            return "[contacorrente]";
        }

        public static string BuscaNomeTabelaIdempontecia()
        {
            return "[idempotencia]";
        }
    }
}