namespace OficinaMeurer.Domain.ViewModel
{
    public class EditarOSViewModel
    {
        public long Id { get; set; }
        public string Solicitacao { get; set; }
        public string? Observacoes { get; set; }
        public IEnumerable<ServicoViewModel> ProdutosOS { get; set; }
        public IEnumerable<ProdutoViewModel> ServicosOS { get; set; }
    }

}
