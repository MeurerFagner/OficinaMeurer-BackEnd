using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaMeurer.Domain.Entidades;

namespace OficinaMeurer.Infra.MapEntidades
{
    public class ServicoOrdemDeServicoMap : EntityMapBase<ServicoOrdemDeServico>
    {
        public override void Configure(EntityTypeBuilder<ServicoOrdemDeServico> builder)
        {
            base.Configure(builder);

            builder.ToTable("SERVICO_ORDEM_DE_SERVICO");

            builder.HasOne(o => o.Servico)
                .WithMany(m => m.ServicoOS)
                .HasForeignKey(fk => fk.IdServico);

            builder.HasOne(o => o.OrdemDeServico)
                .WithMany(m => m.ServicosOS)
                .HasForeignKey(fk => fk.IdOrdemDeServico);
        }
    }
}
