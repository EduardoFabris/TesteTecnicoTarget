using Microsoft.AspNetCore.Mvc;
using DesafioTecnico.API.Services;
using DesafioTecnico.API.DTOs;

namespace DesafioTecnico.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstoqueController : ControllerBase
{
    private readonly EstoqueService _estoqueService;

    public EstoqueController(EstoqueService estoqueService)
    {
        _estoqueService = estoqueService;
    }

    [HttpPost]
    public IActionResult MovimentarEstoque(MovimentacaoEstoqueDTO movimentacao)
    {
        try
        {
            var produto = _estoqueService.MovimentarEstoque(movimentacao);

            return Ok(produto);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                mensagem = ex.Message
            });
        }
    }
}