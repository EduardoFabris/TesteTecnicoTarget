using DesafioTecnico.API.Models;

namespace DesafioTecnico.API.Services;

public class ComissaoService
{
    public ResultadoComissao CalcularComissao(Venda venda)
    {
        if (venda.Valor < 100)
        {
            return new ResultadoComissao
            {
                PercentualComissao = 0,
                ValorComissao = 0
            };
        }

        if (venda.Valor < 500)
        {
            return new ResultadoComissao
            {
                PercentualComissao = 1,

                //É tipo ValorComissao = venda.Valor * 0.01m, porém usamos Math.Round(X, 2) para arredondar esse valor pra 2 casas decimais já que estamos lidando com dinheiro
                ValorComissao = Math.Round(venda.Valor * 0.01m, 2)
            };
        }

        return new ResultadoComissao
        {
            PercentualComissao = 5,
            ValorComissao = Math.Round(venda.Valor * 0.05m, 2)
        };
    }
}