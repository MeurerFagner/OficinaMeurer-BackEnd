namespace OficinaMeurer.Domain.Entidades
{
    public class ProdutoOrdemDeServico: EntidadeBase
    {
        public long IdProduto { get; set; }
        public Produto Produto { get; set; }
        public long IdOrdemDeServico { get; set; }
        public OrdemDeServico OrdemDeServico { get; set; }
    }
}
