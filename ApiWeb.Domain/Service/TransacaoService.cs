using ApiWeb.Domain.Domains;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Domain.Interfaces;
using ApiWeb.Domain.Service.Interface;
using ApiWeb.Domain.Exceptions;

namespace ApiWeb.Domain.Service;

public class TransacaoService : ITransacaoService
{
    private readonly ITransacaoRepository _transacaoRepository;
    private readonly IRegistroFinanceiroService _registroFinanceiroService;
    private readonly IUnitOfWork _unitOfWork;

    public TransacaoService(ITransacaoRepository transacaoRepository, IUnitOfWork unitOfWork, IRegistroFinanceiroService registroFinanceiroService)
    {
        _transacaoRepository = transacaoRepository;
        _unitOfWork = unitOfWork;
        _registroFinanceiroService = registroFinanceiroService;
    }

    public async Task<Transacao> Criar(Transacao transacao)
    {
        Transacao transacaoRetorno;

        var registroFinanceiro = await _registroFinanceiroService.ExisteRegistroFinanceiroAnoMesAtual();

        if (registroFinanceiro is not null)
        {
            transacaoRetorno = registroFinanceiro.AdicionarTransacao(transacao);
        }
        else
        {
            var registroFinanceiroCriado = await _registroFinanceiroService.Criar(new RegistroFinanceiro());
            transacaoRetorno = registroFinanceiroCriado.AdicionarTransacao(transacao);
        }

        await _unitOfWork.CommitAsync();

        return transacaoRetorno;
    }

    public async Task<List<Transacao>> ListarTodas()
    {
       var listarTransacao = await _transacaoRepository.ObterTodosAsync();

       return listarTransacao.OrderBy(x => x.DataCriacao).ToList();
    }

    public async Task<Guid> Remover(Guid id)
    {
        var transacao = await _transacaoRepository.ObterPorIdAsync(id);

        if (transacao is null)
        {
            throw new NotFoundException("Entidade não pode ser encontrada");
        }

        _transacaoRepository.Remover(transacao);

        await _unitOfWork.CommitAsync();

        return id;
    }
}

