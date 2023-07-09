using ApiWeb.Application.Request;
using ApiWeb.Application.Response.BaseResponse;
using ApiWeb.Application.Response.Produto;

namespace ApiWeb.Application.AppService.Interface;

public interface IProdutoAppService
{
    Task<BaseResponse> Criar(CriarProdutoRequest request);
}

