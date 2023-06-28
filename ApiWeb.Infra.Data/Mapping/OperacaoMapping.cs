
using ApiWeb.Domain.EntidadeAbstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWeb.Infra.Data.Mapping;

public class OperacaoMapping : BaseMapping<Operacao>
{
    public override void Configure(EntityTypeBuilder<Operacao> builder)
    {
        base.Configure(builder);

        builder.ToTable("Operacao", Constantes.Schemas.Sistema);
    }
}