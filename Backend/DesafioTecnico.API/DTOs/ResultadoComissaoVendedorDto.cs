namespace DesafioTecnico.API.DTOs;

public class ResultadoComissaoVendedorDto
{
    public string Vendedor { get; set; } = string.Empty;

    public decimal TotalVendas { get; set; }

    public decimal TotalComissao { get; set; }
}