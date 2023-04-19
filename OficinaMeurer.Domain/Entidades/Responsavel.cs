namespace OficinaMeurer.Domain.Entidades
{
    public class Responsavel: EntidadeBase
    {
        public string Nome { get; set; }
        public virtual ICollection<OrdemDeServico> OrdemDeServicos { get; set; }
    }

}
