using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaMeurer.Domain.Entidades;

namespace OficinaMeurer.Infra.MapEntidades
{
    public class ProdutoOrdemDeServicoMap : EntityMapBase<ProdutoOrdemDeServico>
    {
        public override void Configure(EntityTypeBuilder<ProdutoOrdemDeServico> builder)
        {
            base.Configure(builder);

            builder.ToTable("PRODUTO_ORDEM_DE_SERVICO");

            builder.HasOne(o => o.Produto)
                .WithMany(m => m.ProdutoOS)
                .HasForeignKey(fk => fk.IdProduto);

            builder.HasOne(o => o.OrdemDeServico)
                .WithMany(m => m.ProdutosOS)
                .HasForeignKey(fk => fk.IdOrdemDeServico);
        }
    }

}
