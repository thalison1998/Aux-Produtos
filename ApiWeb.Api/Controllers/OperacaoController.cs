using System.Net;
using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.Request;
using ApiWeb.Domain.EntidadeAbstract;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiBase.Api.Controllers;

[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public class OperacaoController : Controller
{
    private readonly IOperacaoAppService _operacaoAppService;

    public OperacaoController(IOperacaoAppService operacaoAppService)
    {
        _operacaoAppService = operacaoAppService;
    }

    [HttpPost]
    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Operacao))]
    [SwaggerOperation(Summary = "Criar operação")]
    public async Task<IActionResult> Criar([FromBody] CriarOperacaoRequest request)
    {
        var registroFinanceiro = await _operacaoAppService.Criar(request);
        return Ok(registroFinanceiro);
    }

    [HttpPut]
    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Operacao))]
    [SwaggerOperation(Summary = "Obtém operação ")]
    public async Task<IActionResult> ObterPorId([FromBody] Guid Id)
    {
        var registroFinanceiro = await _operacaoAppService.ObterPorId(Id);
        return Ok(registroFinanceiro);
    }
}

