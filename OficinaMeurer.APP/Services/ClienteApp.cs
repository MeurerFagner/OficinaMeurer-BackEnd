using AutoMapper;
using OficinaMeurer.Domain.Entidades;
using OficinaMeurer.Domain.Interfaces.Aplication;
using OficinaMeurer.Domain.Interfaces.Infra;
using OficinaMeurer.Domain.ViewModel;

namespace OficinaMeurer.APP.Services
{
    public class ClienteApp : IClienteApp
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteApp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClienteViewModel> Get(long id)
        {
            var cliente = await _unitOfWork.Clientes.Get(id);
            var clienteOutput = _mapper.Map<ClienteViewModel>(cliente);

            return clienteOutput;
        }

        public async Task<IEnumerable<ClienteViewModel>> GetAll()
        {
            var clientes = await _unitOfWork.Clientes.GetAll();
            var clientesOutput = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);

            return clientesOutput;
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
