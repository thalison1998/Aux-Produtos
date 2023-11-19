using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.Request;
using ApiWeb.Application.Response.AutenticacaoResponse;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApiWeb.Api.Controllers;

[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public class UsuarioController : Controller
{
    private readonly IIdentityAppService _identityAppService;

    public UsuarioController(IIdentityAppService identityAppService)
    {
        _identityAppService = identityAppService;
    }

    [HttpPost("criar")]
    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(UsuarioCadastroResponse))]
    [SwaggerOperation(Summary = "Criar usuário")]
    public async Task<IActionResult> Criar([FromBody] UsuarioCadastroRequest request)
    {
        var usuario = await _identityAppService.CadastrarUsuario(request);
        return Ok(usuario);
    }

    [HttpPost("login")]
    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(UsuarioLoginResponse))]
    [SwaggerOperation(Summary = "login usuário")]
    public async Task<IActionResult> Login([FromBody] UsuarioLoginRequest request)
    {
        var usuario = await _identityAppService.Login(request);
        return Ok(usuario);
    }
}

