namespace ApiWeb.Domain.Entidades;

public abstract class Base
{
    public Base()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public int Codigo { get; set; }
    public DateTime DataCriacao { get; private set; } = DateTime.Now;
}