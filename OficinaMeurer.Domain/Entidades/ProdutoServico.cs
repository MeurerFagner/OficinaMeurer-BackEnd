namespace OficinaMeurer.Domain.Entidades
{
    public class ProdutoServico: EntidadeBase
    {
        public long IdProduto { get; set; }
        public Produto Produto { get; set; }
        public long IdServico { get; set; }
        public Servico Servico { get; set; }
    }
}
