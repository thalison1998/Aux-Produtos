using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.Request;
using ApiWeb.Application.Response;
using ApiWeb.Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApiWeb.Api.Controllers;

[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public class TransacaoController : Controller
{
    private readonly ITransacaoAppService _transacaoAppService;

    public TransacaoController(ITransacaoAppService transacaoAppService)
    {
        _transacaoAppService = transacaoAppService;
    }

    //[Authorize]
    [HttpPost]
    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Transacao))]
    [SwaggerOperation(Summary = "Criar transação")]
    public async Task<IActionResult> Criar([FromBody] CriarTransacaoRequest request)
    {
        var transacao = await _transacaoAppService.Criar(request);
        return Ok(transacao);
    }

    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(List<TransacaoResponse>))]
    [SwaggerOperation(Summary = "Listar transação")]
    public async Task<IActionResult> listarTodas()
    {
        var listarTransacao = await _transacaoAppService.ListarTodas();
        return Ok(listarTransacao);
    }

    [HttpDelete]
    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Transacao))]
    [SwaggerOperation(Summary = "Remover transação")]
    public async Task<IActionResult> Remover([FromQuery] RemoverTransacaoRequest request)
    {
        var transacao = await _transacaoAppService.Remover(request);
        return Ok(transacao);
    }
}

