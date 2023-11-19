using ApiWeb.Domain.Domains;

namespace ApiWeb.Domain.Service.Interface;

public interface ITransacaoService
{
    Task<Transacao> Criar(Transacao transacao);
    Task<Guid> Remover(Guid id);
}