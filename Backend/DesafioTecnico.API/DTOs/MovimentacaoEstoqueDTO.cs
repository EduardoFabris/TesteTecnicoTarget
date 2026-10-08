namespace DesafioTecnico.API.DTOs;

public class MovimentacaoEstoqueDTO
{
    //Não tem ID no DTO porque ID é definido pela aplicação no Model, não vem do Client
    public int CodigoProduto { get; set; }
    public string TipoMovimentacao { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int Quantidade { get; set; }
}