namespace CleanArchMvc.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        // Excessões para validação do dominio
        public DomainExceptionValidation(string error) : base(error)
        { 

        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
            
        }
    }
}
