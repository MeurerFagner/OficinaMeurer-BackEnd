using AutoMapper;
using OficinaMeurer.Domain.Entidades;
using OficinaMeurer.Domain.Interfaces.Aplication;
using OficinaMeurer.Domain.Interfaces.Infra;
using OficinaMeurer.Domain.ViewModel;

namespace OficinaMeurer.APP.Services
{
    public class OrdemDeServicoApp : IOrdemDeServicoApp
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdemDeServicoApp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrdemDeServicoViewModel> Get(long id)
        {
            var os = await _unitOfWork.OrdemDeServico.Get(id);
            var osOutput = _mapper.Map<OrdemDeServicoViewModel>(os);

            return osOutput;
        }

        public async Task<IEnumerable<ResumoOSViewModel>> ObterOSIniciadas()
        {
            var os = await _unitOfWork.OrdemDeServico.ObterOSIniciadas();
            var osOutput = _mapper.Map<IEnumerable<ResumoOSViewModel>>(os);

            return osOutput;
        }

        public async Task<IEnumerable<ResumoOSViewModel>> ObterOSNaoIniciadas()
        {
            var os = await _unitOfWork.OrdemDeServico.ObterOSNaoIniciadas();
            var osOutput = _mapper.Map<IEnumerable<ResumoOSViewModel>>(os);

            return osOutput;
        }

        public async Task<IEnumerable<ResumoOSViewModel>> ObterOSFinalizadas()
        {
            var os = await _unitOfWork.OrdemDeServico.ObterOSFinalizadas();
            var osOutput = _mapper.Map<IEnumerable<ResumoOSViewModel>>(os);

            return osOutput;
        }

        public async Task IncluirOS(IncluirOSViewModel osInput)
        {
            var os = _mapper.Map<OrdemDeServico>(osInput);

            await _unitOfWork.OrdemDeServico.Insert(os);
            await _unitOfWork.Commit();
        }

        public async Task EditarOS(EditarOSViewModel osInput)
        {
            var os = await _unitOfWork.OrdemDeServico.Get(osInput.Id);

            os.Solicitacao = osInput.Solicitacao;
            os.Observacoes = osInput.Observacoes;

            os.ServicosOS = _mapper.Map<IEnumerable<ServicoOrdemDeServico>>(osInput.ServicosOS).ToList();
            os.ProdutosOS = _mapper.Map<IEnumerable<ProdutoOrdemDeServico>>(osInput.ProdutosOS).ToList();

            await _unitOfWork.OrdemDeServico.Update(os);
            await _unitOfWork.Commit();
        }

        public async Task IniciarOS(long idOs, long idResponsavel)
        {
            var os = await _unitOfWork.OrdemDeServico.Get(idOs);

            var responsavel = await _unitOfWork.Get<Responsavel>(idResponsavel);

            os.IniciarOS(responsavel);

            await _unitOfWork.OrdemDeServico.Update(os);
            await _unitOfWork.Commit();
        }

        public async Task FinalizarOS(long idOs)
        {
            var os = await _unitOfWork.OrdemDeServico.Get(idOs);

            os.FinalizarOS();

            await _unitOfWork.OrdemDeServico.Update(os);
            await _unitOfWork.Commit();
        }

    }
}
