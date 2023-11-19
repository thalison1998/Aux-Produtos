using ApiWeb.Application.Request;
using ApiWeb.Application.Response.BaseResponse;

namespace ApiWeb.Application.AppService.Interface;

public interface IRegistroFinanceiroAppService
{
    public Task<BaseResponse> Criar(CriarRegistroFinanceiroRequest request);
}