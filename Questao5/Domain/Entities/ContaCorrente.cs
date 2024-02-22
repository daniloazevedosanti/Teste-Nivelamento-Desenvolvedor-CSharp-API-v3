using Questao5.Domain.Enumerators;
using System.Drawing;

namespace Questao5.Domain.Entities
{
    public class ContaCorrente : BaseEntity
    {        
        public ContaCorrente(int numero, string nome) {
            Idcontacorrente = Guid.NewGuid();
            Numero = numero;
            Nome = nome;
        }

        public Guid Idcontacorrente { get; }

        public int Numero { get; set; }

        public string Nome { get; set; }

        public StatusContaCorrente Ativo { get; private set; } = StatusContaCorrente.Ativo;

        public override bool Validar(ref string msgerro)
        {
            if (Numero <= 0)
            {
                msgerro = "INVALID_ACCOUNT";
                return false;
            }

            if (Ativo == StatusContaCorrente.Inativo)
            {
                msgerro = "INACTIVE_ACCOUNT";
                return false;
            }

            return true;
        }
    }
}