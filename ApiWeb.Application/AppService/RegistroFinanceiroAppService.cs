using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.Request;
using ApiWeb.Application.Response.BaseResponse;
using ApiWeb.Domain.Domains;
using ApiWeb.Domain.Service.Interface;
using AutoMapper;
using FluentValidation;

namespace ApiWeb.Application.AppService;

public class RegistroFinanceiroAppService : IRegistroFinanceiroAppService
{
    private readonly IRegistroFinanceiroService _registroFinanceiroService;
    private readonly IMapper _mapper;

    public RegistroFinanceiroAppService(IRegistroFinanceiroService registroFinanceiroService, IMapper mapper)
    {
        _registroFinanceiroService = registroFinanceiroService;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Criar(CriarRegistroFinanceiroRequest request)
    {
        if (!request.EhValido())
        {
            throw new ValidationException(request.Validar().Errors);
        }

        RegistroFinanceiro registroFinanceiro = _mapper.Map<RegistroFinanceiro>(request);

        var registroFinanceiroResultado = await _registroFinanceiroService.Criar(registroFinanceiro);

        BaseResponseFactory adicionarFactory = new AdicionarBaseResponseFactory();

        return adicionarFactory.CriarBaseResponse("Registro financeiro adicionado com sucesso.", registroFinanceiroResultado.Id);
    }
}