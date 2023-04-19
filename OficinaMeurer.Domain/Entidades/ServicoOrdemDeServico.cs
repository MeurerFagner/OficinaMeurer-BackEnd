namespace OficinaMeurer.Domain.Entidades
{
    public class ServicoOrdemDeServico: EntidadeBase
    {
        public long IdServico { get; set; }
        public Servico Servico { get; set; }
        public long IdOrdemDeServico { get; set; }
        public OrdemDeServico OrdemDeServico { get; set; }
    }
}
