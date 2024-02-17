namespace ApiWeb.Domain.Domains;

public class Itens : Base
{
    public Itens()
    {
    }

    public Itens(string descricao, int quantidade, bool concluido, decimal precoUnidade)
    {
        if (PrecoUnidade < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(PrecoUnidade), "O preço da unidade não pode ser menor que 0.");
        }

        if (Quantidade < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(Quantidade), "A quantidade de unidades não pode ser menor que 0.");
        }

        Descricao = descricao;
        Quantidade = quantidade;
        Concluido = concluido;
        PrecoUnidade = precoUnidade;
    }

    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public bool Concluido { get; set; }
    public decimal PrecoUnidade { get; set; }
    public decimal PrecoTotal { get => CalculoTotal(); }

    private decimal CalculoTotal()
    {
        return PrecoUnidade * Quantidade;
    }
}
