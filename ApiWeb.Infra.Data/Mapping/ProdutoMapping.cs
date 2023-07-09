
using ApiWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWeb.Infra.Data.Mapping;

public class ProdutoMapping : BaseMapping<Produto>
{
    public override void Configure(EntityTypeBuilder<Produto> builder)
    {
        base.Configure(builder);

        builder.ToTable("Produto", Constantes.Schemas.Sistema);
    }
}