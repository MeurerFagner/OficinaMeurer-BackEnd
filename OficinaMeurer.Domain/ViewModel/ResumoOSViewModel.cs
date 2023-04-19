namespace OficinaMeurer.Domain.ViewModel
{
    public class ResumoOSViewModel
    {
        public long Id { get; set; }
        public long IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public long? IdResponsavel { get; set; }
        public string? NomeResponsavel { get; set; }
        public string Solicitacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime Datafim { get; set; }
        public decimal Valor { get; set; }
    }

}
