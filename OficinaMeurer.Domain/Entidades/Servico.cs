namespace OficinaMeurer.Domain.Entidades
{
    public class Servico: EntidadeBase
    {
        public string Descricao { get; set; }
        public decimal? ValorMaoDeObra { get; set; }
        public string? Observacoes { get; set; }

        public virtual ICollection<ProdutoServico> ProdutosServico { get; set; }
        public virtual ICollection<ServicoOrdemDeServico> ServicoOS { get; set; }
    }
}
