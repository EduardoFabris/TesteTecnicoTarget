using DesafioTecnico.API.DTOs;
using DesafioTecnico.API.Models;

namespace DesafioTecnico.API.Services;

public class JurosService
{
    public CalculoJurosResponseDTO CalcularJuros(CalculoJuros calculo)
    {
        if (calculo.ValorOriginal <= 0)
        {
            throw new Exception("O valor original deve ser maior que zero.");
        }

        if (decimal.Round(calculo.ValorOriginal, 2) != calculo.ValorOriginal)
        {
            throw new Exception("O valor original deve ter no máximo duas casas decimais.");
        }

        if (calculo.DataVencimento == DateTime.MinValue)
        {
            throw new Exception("A data de vencimento é obrigatória e deve ser válida.");
        }

        int diasAtraso = (DateTime.Today - calculo.DataVencimento.Date).Days;

        if (diasAtraso < 0)
        {
            diasAtraso = 0;
        }

        decimal valorJuros = calculo.ValorOriginal * 0.025m * diasAtraso;

        decimal valorTotal = calculo.ValorOriginal + valorJuros;

        return new CalculoJurosResponseDTO
        {
            ValorOriginal = calculo.ValorOriginal,
            DataVencimento = calculo.DataVencimento,
            DiasAtraso = diasAtraso,
            ValorJuros = Math.Round(valorJuros, 2),
            ValorTotal = Math.Round(valorTotal, 2)
        };
    }
}