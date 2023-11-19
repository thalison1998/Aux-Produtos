using ApiWeb.Application.Request;
using ApiWeb.Application.Response;
using ApiWeb.Domain.Domains;
using AutoMapper;

namespace ApiWeb.Application.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        #region RegistroFinanceiro
        CreateMap<RegistroFinanceiro, CriarRegistroFinanceiroRequest>().ReverseMap();
        CreateMap<RegistroFinanceiro, RegistroFinanceiroResponse>().ReverseMap();
        #endregion

        #region Transacao
        CreateMap<Transacao, CriarTransacaoRequest>().ReverseMap();
        CreateMap<Transacao, TransacaoResponse>().ReverseMap();
        #endregion
    }
}
