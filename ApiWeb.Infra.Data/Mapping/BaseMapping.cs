using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ApiWeb.Domain.Domains;

namespace ApiWeb.Infra.Data.Mapping;

public abstract class BaseMapping<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Base
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataCriacao).HasColumnType("timestamp");
        builder.Property(x => x.Codigo).ValueGeneratedOnAdd();
    }
}