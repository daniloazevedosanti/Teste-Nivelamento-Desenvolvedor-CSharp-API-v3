namespace Questao5.Infrastructure.Database.Shared
{
    public abstract class BaseQuery
    {
        public string? Table { get; set; }
        public string? Innertable { get; set; }
        public string? Query { get; set; }
        public object? Parametros { get; set; }
    }
}