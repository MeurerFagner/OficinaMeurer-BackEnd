using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaMeurer.Domain.Entidades;

namespace OficinaMeurer.Infra.MapEntidades
{
    public class OrdemDeServicoMap : EntityMapBase<OrdemDeServico>
    {
        public override void Configure(EntityTypeBuilder<OrdemDeServico> builder)
        {
            base.Configure(builder);

            builder.ToTable("ORDEM_DE_SERVICO");

            builder.HasOne(o => o.Cliente)
                .WithMany(m => m.OrdemDeServicos)
                .HasForeignKey(fk => fk.IdCliente);

            builder.HasOne(o => o.Responsavel)
                .WithMany(m => m.OrdemDeServicos)
                .HasForeignKey(fk => fk.IdResponsavel);
        }
    }

}
