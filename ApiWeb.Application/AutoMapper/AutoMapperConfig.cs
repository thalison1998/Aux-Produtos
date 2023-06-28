using ApiWeb.Application.Request;
using ApiWeb.Application.Response;
using ApiWeb.Domain.EntidadeAbstract;
using ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;
using ApiWeb.Domain.Entidades.RegistroFinanceiro;
using AutoMapper;

namespace ApiWeb.Application.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        #region Operacao
        CreateMap<OperacaoEntrada, CriarOperacaoRequest>().ReverseMap();
        CreateMap<OperacaoSaida, CriarOperacaoRequest>().ReverseMap();
        CreateMap<Operacao, OperacaoResponse>().ReverseMap();
        #endregion

        #region RegistroFinanceiro
        CreateMap<RegistroFinanceiro, CriarRegistroFinanceiroRequest>().ReverseMap();

        CreateMap<RegistroFinanceiro, RegistroFinanceiroResponse>().ReverseMap();
        #endregion
    }
}
