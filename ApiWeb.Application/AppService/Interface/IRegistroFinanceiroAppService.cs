using ApiWeb.Application.Request;
using ApiWeb.Application.Response;
using ApiWeb.Domain.EntidadeAbstract;
using ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;

namespace ApiWeb.Application.AppService.Interface;

public interface IRegistroFinanceiroAppService
{
    Task<RegistroFinanceiroResponse> Criar(CriarRegistroFinanceiroRequest request);
    void AtualizarValorTotalRegistroFinanceiro(Operacao operacao, RegistroFinanceiro registroFinanceiro);
}