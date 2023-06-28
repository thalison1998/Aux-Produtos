using System.Net;
using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.Request;
using ApiWeb.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiBase.Api.Controllers;

[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public class RegistroFinanceiroController : Controller
{
    private readonly IRegistroFinanceiroAppService _registroFinanceiroAppService;

    public RegistroFinanceiroController(IRegistroFinanceiroAppService registroFinanceiroAppService)
    {
        _registroFinanceiroAppService = registroFinanceiroAppService;
    }

    [HttpPost]
    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(RegistroFinanceiroResponse))]
    [SwaggerOperation(Summary = "Criar registro financeiro")]
    public async Task<IActionResult> Criar([FromBody] CriarRegistroFinanceiroRequest request)
    {
        var registroFinanceiro = await _registroFinanceiroAppService.Criar(request);
        return Ok(registroFinanceiro);
    }
}