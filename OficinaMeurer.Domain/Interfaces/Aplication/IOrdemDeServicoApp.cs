using OficinaMeurer.Domain.ViewModel;

namespace OficinaMeurer.Domain.Interfaces.Aplication
{
    public interface IOrdemDeServicoApp
    {
        Task EditarOS(EditarOSViewModel osInput);
        Task FinalizarOS(long idOs);
        Task<OrdemDeServicoViewModel> Get(long id);
        Task IncluirOS(IncluirOSViewModel osInput);
        Task IniciarOS(long idOs, long idResponsavel);
        Task<IEnumerable<ResumoOSViewModel>> ObterOSFinalizadas();
        Task<IEnumerable<ResumoOSViewModel>> ObterOSIniciadas();
        Task<IEnumerable<ResumoOSViewModel>> ObterOSNaoIniciadas();
    }

}
