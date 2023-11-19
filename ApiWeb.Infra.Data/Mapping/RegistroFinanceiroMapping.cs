using ApiWeb.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWeb.Infra.Data.Mapping;

public class RegistroFinanceiroMapping : BaseMapping<RegistroFinanceiro>
{
    public override void Configure(EntityTypeBuilder<RegistroFinanceiro> builder)
    {
        base.Configure(builder);

        builder.ToTable("RegistrosFinanceiros", Constantes.Schemas.Sistema);

        builder.Property(x => x.ValorTotal).HasColumnType("decimal");
    }
}