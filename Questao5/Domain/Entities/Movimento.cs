namespace Questao5.Domain.Entities
{
    public class Movimento : BaseEntity
    {
        public Movimento(ContaCorrente contacorrente, char tipo, decimal valor) {
            Idmovimento = Guid.NewGuid();
            Contacorrente = contacorrente;
            Datamovimento = DateTime.Now;
            Tipomovimento = tipo;
            Valor = valor;
        }

        public Guid Idmovimento { get; set; }
        public ContaCorrente Contacorrente { get; set; }
        public DateTime Datamovimento { get; set; }
        public char Tipomovimento { get; set; }
        public decimal Valor { get; set; }

        public override bool Validar(ref string msgerro)
        {
            if (Valor <= 0)
            {
                msgerro = "INVALID_VALUE";
                return false;
            }

            if (Tipomovimento != 'C' & Tipomovimento != 'D')
            {
                msgerro = "INVALID_TYPE";
                return false;
            }

            return true;
        }
    }    
}