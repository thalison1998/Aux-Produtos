using ApiWeb.Application.AppService.Interface;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Domain.Interfaces;
using AutoMapper;
using ApiWeb.Application.Response;
using ApiWeb.Application.Request;
using ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;
using ApiWeb.Domain.EntidadeAbstract;
using ApiWeb.Domain.Enums;

namespace ApiWeb.Application.AppService;
public class RegistroFinanceiroAppService : IRegistroFinanceiroAppService
{
    private readonly IRegistroFinanceiroRepository _registroFinanceiroRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegistroFinanceiroAppService(IRegistroFinanceiroRepository registroFinanceiroRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _registroFinanceiroRepository = registroFinanceiroRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void AtualizarValorTotalRegistroFinanceiro(Operacao operacao, RegistroFinanceiro registroFinanceiro)
    {
        switch (operacao.TipoFinanceiro)
        {
            case EnumTipoFinanceiro.Entrada:
                registroFinanceiro.AtualizarValorPositivo(operacao.Valor);
                break;
            case EnumTipoFinanceiro.Saida:
                registroFinanceiro.AtualizarValorNegativo(operacao.Valor);
                break;
            default:
                break; // depois implementar alguma notificação.
        }
    }

    private void AtribuicaoDeValorPositivoNegativos(OperacaoCreate factory, CriarRegistroFinanceiroRequest request, RegistroFinanceiro registroFinanceiro)
    {
        foreach (var operacaos in request.Operacoes)
        {
            var operacao = factory.CriarOperacao(operacaos.TipoFinanceiro, operacaos.Valor, registroFinanceiro.Id);

            registroFinanceiro.AdicionarOperacao(operacao);

            AtualizarValorTotalRegistroFinanceiro(operacao, registroFinanceiro);
        }
    }

    public async Task<RegistroFinanceiroResponse> Criar(CriarRegistroFinanceiroRequest request)
    {
        var registroFinanceiro = new RegistroFinanceiro(request.Descricao);

        OperacaoCreate factory = new OperacaoCreate();

        AtribuicaoDeValorPositivoNegativos(factory, request, registroFinanceiro);

        registroFinanceiro = _registroFinanceiroRepository.Adicionar(registroFinanceiro);

        await _unitOfWork.CommitAsync();

        var registroFinanceiroMapeado = _mapper.Map<RegistroFinanceiroResponse>(registroFinanceiro);

        return registroFinanceiroMapeado;
    }

    public async Task<RegistroFinanceiroResponse> ObterPorId(Guid id)
    {
        var registroFinanceiroMapeado = await _registroFinanceiroRepository.ObterPorIdComOperacaoAsync(id);

        return _mapper.Map<RegistroFinanceiroResponse>(registroFinanceiroMapeado);
    }
}