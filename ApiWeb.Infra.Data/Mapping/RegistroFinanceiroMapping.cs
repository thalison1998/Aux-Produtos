using ApiWeb.Infra.Data.Mapping;
using ApiWeb.Infra.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiWeb.Domain.Entidades.GrupoRegistroFinanceiro;
using Microsoft.EntityFrameworkCore;

public class RegistroFinanceiroMapping : BaseMapping<RegistroFinanceiro>
{
    public override void Configure(EntityTypeBuilder<RegistroFinanceiro> builder)
    {
        base.Configure(builder);

        builder.ToTable("RegistroFinanceiro", Constantes.Schemas.Sistema);
    }
}