using ApiWeb.Application.Request;
using ApiWeb.Application.Response.Produto;
using ApiWeb.Domain.Entidades;
using AutoMapper;

namespace ApiWeb.Application.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        #region Produto
        CreateMap<Produto, CriarProdutoRequest>().ReverseMap();
        CreateMap<Produto, ProdutoResponse>().ReverseMap();
        #endregion
    }
}
