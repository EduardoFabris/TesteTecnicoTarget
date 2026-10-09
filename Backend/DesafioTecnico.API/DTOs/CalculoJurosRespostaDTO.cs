
namespace DesafioTecnico.API.DTOs;

public class CalculoJurosResponseDTO
{
    public decimal ValorOriginal { get; set; }

    public DateTime DataVencimento { get; set; }

    public int DiasAtraso { get; set; }

    public decimal ValorJuros { get; set; }

    public decimal ValorTotal { get; set; }
}