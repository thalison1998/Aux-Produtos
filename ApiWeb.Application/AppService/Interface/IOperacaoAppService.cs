using ApiWeb.Application.Request;
using ApiWeb.Application.Response;

namespace ApiWeb.Application.AppService.Interface;

public interface IOperacaoAppService
{
    Task<OperacaoResponse> Criar(CriarOperacaoRequest request);
    Task<OperacaoResponse> ObterPorId(Guid id);
}