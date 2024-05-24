using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        // Construtores parametrizados para permitir criar os objetos
        public Category(string name)
        {
            ValidateDomain(name);  
        }

        // Esse construtor será utilizado para popular os valores na tabela
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }
        public ICollection<Product> Products { get; private set;}

        // Lógica de validação do nome vazio ou quantidade de caracteres
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short minimal 3 characteres");

            Name = name;

        }
    }
}
