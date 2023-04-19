namespace OficinaMeurer.Domain.Entidades
{
    public class Produto: EntidadeBase
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<ProdutoServico> ProdutoServicos { get; set; }
        public virtual ICollection<ProdutoOrdemDeServico> ProdutoOS { get; set; }
    }
}
