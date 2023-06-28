using ApiWeb.Application.Request;
using ApiWeb.Domain.EntidadeAbstract;
using ApiWeb.Domain.Entidades.RegistroFinanceiro;
using AutoMapper;

namespace ApiWeb.Application.AutoMapper;

public class OperacaoResolver : IValueResolver<Operacao, CriarOperacaoRequest, CriarOperacaoRequest>
{
    public CriarOperacaoRequest Resolve(Operacao source, CriarOperacaoRequest destination, CriarOperacaoRequest destMember, ResolutionContext context)
    {
        CriarOperacaoRequest operacaoRequest = source switch
        {
            OperacaoEntrada entrada => context.Mapper.Map<OperacaoEntrada, CriarOperacaoRequest>(entrada),
            OperacaoSaida saida => context.Mapper.Map<OperacaoSaida, CriarOperacaoRequest>(saida),
            _ => throw new ArgumentException("Tipo de operação inválido.")
        };

        return operacaoRequest;
    }
}
