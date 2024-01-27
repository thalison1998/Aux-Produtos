using ApiWeb.Application.Request;
using ApiWeb.Application.Response;
using ApiWeb.Application.Response.BaseResponse;

namespace ApiWeb.Application.AppService.Interface;

public interface IRegistroFinanceiroAppService
{
    Task<BaseResponse> Criar(CriarRegistroFinanceiroRequest request);
    Task<RegistroFinanceiroResponse> ObterRegistroFinanceiroAnoMesAtual();
}