using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaMeurer.Domain.Entidades;

namespace OficinaMeurer.Infra.MapEntidades
{
    public abstract class EntityMapBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity: EntidadeBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
