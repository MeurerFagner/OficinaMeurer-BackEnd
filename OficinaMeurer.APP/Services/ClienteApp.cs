using AutoMapper;
using OficinaMeurer.Domain.Entidades;
using OficinaMeurer.Domain.Interfaces.Aplication;
using OficinaMeurer.Domain.Interfaces.Infra;
using OficinaMeurer.Domain.ViewModel;

namespace OficinaMeurer.APP.Services
{
    public class ClienteApp: IClienteApp
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteApp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Cliente> Get(long id)
        {
            return await _unitOfWork.Clientes.Get(id);
        }

        public Task<IEnumerable<Cliente>> GetAll()
        {
            return _unitOfWork.Clientes.GetAll();
        }

        public async Task Salvar(ClienteViewModel clienteInput)
        {
            var cliente = _mapper.Map<Cliente>(clienteInput);

            if (clienteInput.Id.HasValue)
                await _unitOfWork.Clientes.Update(cliente);
            else
                await _unitOfWork.Clientes.Insert(cliente);

            await _unitOfWork.Commit();
        }
    }
}
