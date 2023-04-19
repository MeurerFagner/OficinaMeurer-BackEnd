using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaMeurer.Domain.Entidades;

namespace OficinaMeurer.Infra.MapEntidades
{
    public class ServicoMap : EntityMapBase<Servico>
    {
        public override void Configure(EntityTypeBuilder<Servico> builder)
        {
            base.Configure(builder);

            builder.ToTable("SERVICO");
        }
    }



}
