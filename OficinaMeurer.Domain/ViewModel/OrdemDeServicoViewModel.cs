namespace OficinaMeurer.Domain.ViewModel
{
    public class OrdemDeServicoViewModel
    {
        public long Id { get; set; }
        public long IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public long? IdResponsavel { get; set; }
        public string? NomeResponsavel { get; set; }
        public string Solicitacao { get; set; }
        public string? Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime Datafim { get; set; }
        public IEnumerable<ServicoViewModel> ProdutosOS { get; set; }
        public IEnumerable<ProdutoViewModel> ServicosOS { get; set; }
        public decimal Valor { get; set; }
    }

}
