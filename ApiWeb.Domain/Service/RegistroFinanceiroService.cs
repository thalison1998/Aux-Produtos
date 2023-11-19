using ApiWeb.Domain.Domains;
using ApiWeb.Domain.Interfaces.IRepository;
using ApiWeb.Domain.Interfaces;
using ApiWeb.Domain.Service.Interface;

namespace ApiWeb.Domain.Service;

public class RegistroFinanceiroService : IRegistroFinanceiroService
{
    private readonly IRegistroFinanceiroRepository _registroFinanceiroRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegistroFinanceiroService(IRegistroFinanceiroRepository registroFinanceiroRepository, IUnitOfWork unitOfWork)
    {
        _registroFinanceiroRepository = registroFinanceiroRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegistroFinanceiro> Criar(RegistroFinanceiro registroFinanceiro)
    {
        var registroFinanceiroRetorno = _registroFinanceiroRepository.Adicionar(registroFinanceiro);

        await _unitOfWork.CommitAsync();

        return registroFinanceiroRetorno;
    }

    public Task<RegistroFinanceiro> ExisteRegistroFinanceiroAnoMesAtual() => _registroFinanceiroRepository.ExisteRegistroFinanceiroAnoMesAtual();

    //public Task<List<RegistroFinanceiro>> ListarTodosRegistrosFinanceiros()
    //{
    //    var listaDeRegistrosFinanceiros = _registroFinanceiroRepository.ObterTodosAsync();
    //}
}