namespace ApiWeb.Domain.Entidades;

public class Produto : Base
{
    public Produto(string nome, decimal valor)
    {
        Nome = nome;
        Valor = valor;
    }

    public string Nome { get; private set; }
    public decimal Valor { get; private set; }
}