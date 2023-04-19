using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaMeurer.Domain.Entidades;

namespace OficinaMeurer.Infra.MapEntidades
{
    public class ProdutoServicoMap : EntityMapBase<ProdutoServico>
    {
        public override void Configure(EntityTypeBuilder<ProdutoServico> builder)
        {
            base.Configure(builder);

            builder.ToTable("PRODUTO_SERVICO");

            builder.HasOne(o => o.Produto)
                .WithMany(m => m.ProdutoServicos)
                .HasForeignKey(fk => fk.IdProduto);

            builder.HasOne(o => o.Servico)
                .WithMany(m => m.ProdutosServico)
                .HasForeignKey(fk => fk.IdServico);
        }
    }


}
