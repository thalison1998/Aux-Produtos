using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.Request;
using ApiWeb.Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using ApiWeb.Application.Response.BaseResponse;
using ApiWeb.Infra.CrossCutting.Core;

namespace ApiWeb.Api.Controllers
{
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

        [Authorize]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(BaseResponse))]
        [SwaggerOperation(Summary = DescricoesSwagger.DescricaoRegistroFinanceiro.Criar)]
        public async Task<IActionResult> Criar([FromBody] CriarRegistroFinanceiroRequest request)
        {
            var registroFinanceiro = await _registroFinanceiroAppService.Criar(request);
            return Ok(registroFinanceiro);
        }
    }
}
