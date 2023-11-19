using ApiWeb.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWeb.Infra.Data.Mapping;

public class TransacaoMapping : BaseMapping<Transacao>
{
    public override void Configure(EntityTypeBuilder<Transacao> builder)
    {
        base.Configure(builder);

        builder.ToTable("Transacoes", Constantes.Schemas.Sistema);

        builder.Property(x => x.ValorTransacao).HasColumnType("decimal");
    }
}