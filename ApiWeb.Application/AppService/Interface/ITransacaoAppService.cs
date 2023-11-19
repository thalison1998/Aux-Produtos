using ApiWeb.Application.Request;
using ApiWeb.Application.Response.BaseResponse;

namespace ApiWeb.Application.AppService.Interface;
public interface ITransacaoAppService
{
    public Task<BaseResponse> Criar(CriarTransacaoRequest request);
    Task<BaseResponse> Remover(RemoverTransacaoRequest request);
}
