using DesafioTecnico.API.DTOs;
using DesafioTecnico.API.Models;
using DesafioTecnico.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComissaoController : ControllerBase
{
    private readonly ComissaoService _comissaoService;

    public ComissaoController(ComissaoService comissaoService)
    {
        _comissaoService = comissaoService;
    }

    [HttpPost]
    public IActionResult CalcularComissao(ListaVendas listaVendas)
    {
        var resultados = new List<ResultadoComissaoDto>();

        foreach (var venda in listaVendas.Vendas)
        {
            var resultado = _comissaoService.CalcularComissao(venda);

            resultados.Add(new ResultadoComissaoDto
            {
                Vendedor = venda.Vendedor,
                ValorVenda = venda.Valor,
                PercentualComissao = resultado.PercentualComissao,
                ValorComissao = resultado.ValorComissao
            });
        }

        var resultadoPorVendedor = resultados

            //Agrupa vendas com mesmo vendedor
            .GroupBy(r => r.Vendedor)

            //Busca pelo agrupamento, total de vendas e total da comissao do vendedor
            .Select(grupo => new ResultadoComissaoVendedorDto
            {
                Vendedor = grupo.Key,
                //Soma o valor de todas as vendas desse vendedor.
                TotalVendas = grupo.Sum(r => r.ValorVenda),

                //Soma as comissões que já foram calculadas individualmente.
                TotalComissao = grupo.Sum(r => r.ValorComissao)
            })

            //lista essas coisas e retorna
            .ToList();

        return Ok(resultadoPorVendedor);
    }
}