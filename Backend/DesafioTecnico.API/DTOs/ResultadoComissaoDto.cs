namespace DesafioTecnico.API.DTOs;

public class ResultadoComissaoDto
{
    public string Vendedor { get; set; } = string.Empty;

    public decimal ValorVenda { get; set; }

    public decimal PercentualComissao { get; set; }

    public decimal ValorComissao { get; set; }
}