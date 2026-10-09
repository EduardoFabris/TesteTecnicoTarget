
using Microsoft.AspNetCore.Mvc;
using DesafioTecnico.API.Models;
using DesafioTecnico.API.Services;

namespace DesafioTecnico.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JurosController : ControllerBase
{
    private readonly JurosService _jurosService;

    public JurosController()
    {
        _jurosService = new JurosService();
    }

    [HttpPost("calcular")]
    public ActionResult CalcularJuros([FromBody] CalculoJuros calculo)
    {
        try
        {
            var resultado = _jurosService.CalcularJuros(calculo);

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }
}