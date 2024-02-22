namespace Questao5.Domain.Entities
{
    public abstract class BaseEntity
    {        
        public virtual bool Validar(ref string msgerro)
        {
            return true;
        }
    }
}