namespace CleanArchMvc.Domain.Validation
{
    public class DomainExceptionValidation(string error) : Exception(error)
    {
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
            
        }
    }
}
