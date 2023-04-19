namespace OficinaMeurer.Domain.Entidades
{
    public class OrdemDeServico: EntidadeBase
    {
        public long IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public long? IdResponsavel { get; set; }
        public Responsavel Responsavel { get; set; }
        public string Solicitacao { get; set; }
        public string? Observacoes { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public virtual ICollection<ProdutoOrdemDeServico> ProdutosOS { get; set; }
        public virtual ICollection<ServicoOrdemDeServico> ServicosOS { get; set; }

        public void IniciarOS(Responsavel responsavel)
        {
            Responsavel = responsavel;
            DataInicio = DateTimeOffset.Now.DateTime;
        }

        public void FinalizarOS()
        {
            DataFim = DateTimeOffset.Now.DateTime;
        }
    }
}
