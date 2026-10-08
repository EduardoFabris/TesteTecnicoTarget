namespace DesafioTecnico.API.Models;

public class MovimentacaoEstoque
{
    public int Id { get; set; }
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; } = string.Empty;
    public string TipoMovimentacao { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public int EstoqueAtual { get; set; }
}