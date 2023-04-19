using OficinaMeurer.Domain.Entidades;
using OficinaMeurer.Domain.ViewModel;

namespace OficinaMeurer.Domain.Interfaces.Aplication
{
    public interface IClienteApp
    {
        Task<IEnumerable<ClienteViewModel>> GetAll();
        Task<ClienteViewModel> Get(long id);
        Task Salvar(ClienteViewModel cliente);
    }

}
