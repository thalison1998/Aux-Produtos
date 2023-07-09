using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.Request;
using ApiWeb.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApiBase.Api.Controllers;

[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public class ProdutoController : Controller
{
    private readonly IProdutoAppService _produtoAppService;

    public ProdutoController(IProdutoAppService produtoAppService)
    {
        _produtoAppService = produtoAppService;
    }

    [HttpPost]
    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Produto))]
    [SwaggerOperation(Summary = "Criar operação")]
    public async Task<IActionResult> Criar([FromBody] CriarProdutoRequest request)
    {
        var produto = await _produtoAppService.Criar(request);
        return Ok(produto);
    }
}

