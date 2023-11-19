namespace ApiWeb.Domain.Domains;

public abstract class Base
{
    public Base()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public int Codigo { get; set; }
    public DateTime DataCriacao { get; private set; } = DateTime.Now;

    public void LimparId()
    {
        Id = Guid.Empty;
    }
}