using OficinaMeurer.Domain.Entidades;

namespace OficinaMeurer.Domain.Interfaces.Infra
{
    public interface IClienteRepositorio: IRepositorioBase<Cliente>
    {

    }

    public interface IOrdemDeServicoRepositorio : IRepositorioBase<OrdemDeServico>
    {
        Task<IEnumerable<OrdemDeServico>> ObterOSFinalizadas();
        Task<IEnumerable<OrdemDeServico>> ObterOSIniciadas();
        Task<IEnumerable<OrdemDeServico>> ObterOSNaoIniciadas();
    }

}
