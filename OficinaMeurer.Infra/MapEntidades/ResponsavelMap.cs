using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaMeurer.Domain.Entidades;

namespace OficinaMeurer.Infra.MapEntidades
{
    public class ResponsavelMap : EntityMapBase<Responsavel>
    {
        public override void Configure(EntityTypeBuilder<Responsavel> builder)
        {
            base.Configure(builder);

            builder.ToTable("RESPONSAVEL");
        }
    }


}
