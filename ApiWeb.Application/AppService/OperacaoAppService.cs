using ApiWeb.Application.AppService.Interface;
using ApiWeb.Application.ErrorMiddleware;
using ApiWeb.Application.Request;
using ApiWeb.Application.Response;
using ApiWeb.Domain.EntidadeAbstract;
using ApiWeb.Domain.EntidadeAbstract.Interfaces;
using ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;
using ApiWeb.Domain.Interfaces;
using ApiWeb.Domain.Interfaces.IRepository;
using AutoMapper;

namespace ApiWeb.Application.AppService;

public class OperacaoAppService : IOperacaoAppService
{
    private readonly IOperacaoRepository _operacaoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRegistroFinanceiroRepository _financeiroRepository;
    private readonly IRegistroFinanceiroAppService _financeiroAppService;

    public OperacaoAppService(IOperacaoRepository operacaoRepository, IUnitOfWork unitOfWork, IMapper mapper,
                                IRegistroFinanceiroRepository financeiroRepository, IRegistroFinanceiroAppService financeiroAppService)
    {
        _operacaoRepository = operacaoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _financeiroRepository = financeiroRepository;
        _financeiroAppService = financeiroAppService;
    }
    private void AtualizarValorTotal (Operacao operacao, RegistroFinanceiro registroFinanceiro) => _financeiroAppService.AtualizarValorTotalRegistroFinanceiro(operacao, registroFinanceiro);

    public async Task<OperacaoResponse> Criar(CriarOperacaoRequest request)
    {
        OperacaoCreate factory = new OperacaoCreate();

        Operacao operacao = factory.CriarOperacao(request.TipoFinanceiro, request.Valor, request.RegistroFinanceiroId);

        var registroFinanceiro = await _financeiroRepository.ObterPorIdComOperacaoAsync(request.RegistroFinanceiroId);

        var operacaoCriada = _operacaoRepository.Adicionar(operacao);

        AtualizarValorTotal(operacao, registroFinanceiro);

        await _unitOfWork.CommitAsync();

        var operacaoResponseMapeado = _mapper.Map<OperacaoResponse>(operacaoCriada);

        return operacaoResponseMapeado;
    }

    public async Task<OperacaoResponse> ObterPorId(Guid id)
    {
        var registroFinanceiro = await _operacaoRepository.ObterPorIdAsync(id);

        if (registroFinanceiro == null)
            throw new NotFoundException("Operação não encontrado");

        var registroFinanceiroResponseMapeado = _mapper.Map<OperacaoResponse>(registroFinanceiro);

        await _unitOfWork.CommitAsync();

        return registroFinanceiroResponseMapeado;
    }
}

