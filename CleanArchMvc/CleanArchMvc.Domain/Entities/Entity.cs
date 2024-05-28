namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        //Classe base para ser herdada em Product e Category
        public int Id { get; protected set; }
    }
}
