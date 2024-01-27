using ApiWeb.Domain.Domains;
using ApiWeb.Application.AppService.Interface;
using ApiWeb.Domain.Service.Interface;
using ApiWeb.Application.Response.BaseResponse;
using ApiWeb.Application.Request;
using AutoMapper;
using FluentValidation;
using ApiWeb.Application.Response;

namespace ApiWeb.Application.AppService;

public class TransacaoAppService : ITransacaoAppService
{
    private readonly ITransacaoService _transacaoService;
    private readonly IMapper _mapper;

    public TransacaoAppService(ITransacaoService transacaoService, IMapper mapper)
    {
        _transacaoService = transacaoService;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Criar(CriarTransacaoRequest request)
    {
        if (!request.EhValido())
        {
            throw new ValidationException(request.Validar().Errors);
        }

        Transacao transacao = _mapper.Map<Transacao>(request);

        var transacaoResultado = await _transacaoService.Criar(transacao);

        BaseResponseFactory adicionarFactory = new AdicionarBaseResponseFactory();

        return adicionarFactory.CriarBaseResponse("Transação adicionado com sucesso.", transacaoResultado.Id);
    }

    public async Task<List<TransacaoResponse>> ListarTodas()
    {
        var transacaoResultado = await _transacaoService.ListarTodas();

        List<TransacaoResponse> listaTransacaorResponse = _mapper.Map<List<TransacaoResponse>>(transacaoResultado);

        return listaTransacaorResponse;
    }

    public async Task<BaseResponse> Remover(RemoverTransacaoRequest request)
    {
        //if (!request.EhValido())
        //{
        //    throw new ValidationException(request.Validar().Errors);
        //}

        var transacaoId = await _transacaoService.Remover(request.Id);

        BaseResponseFactory adicionarFactory = new RemoverBaseResponseFactory();

        return adicionarFactory.CriarBaseResponse("Transação removida com sucesso.", transacaoId);
    }
}