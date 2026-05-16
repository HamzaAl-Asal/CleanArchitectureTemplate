namespace CleanArchitectureTemplate.Domain.Entities
{
    public abstract class BaseEntity<T> where T : notnull
    {
        public required T Id { get; set; }
    }
}