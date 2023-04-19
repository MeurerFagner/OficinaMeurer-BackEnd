using Microsoft.EntityFrameworkCore;
using OficinaMeurer.Domain.Entidades;
using OficinaMeurer.Domain.Interfaces.Infra;

namespace OficinaMeurer.Infra.Repositorios
{
    public class OrdemDeServicoRepositorio : RepositorioBase<OrdemDeServico>, IOrdemDeServicoRepositorio
    {
        public OrdemDeServicoRepositorio(Context context) : base(context)
        {
        }

        public override async Task<OrdemDeServico> Get(long id)
        {
            var os = await _context
                .OrdemsDeServicos
                .Include(i => i.Cliente)
                .Include(i => i.Responsavel)
                .Include(i => i.ServicosOS)
                    .ThenInclude(i => i.Servico)
                .Include(i => i.ProdutosOS)
                    .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(o => o.Id == id);

            return os;
        }

        public async Task<IEnumerable<OrdemDeServico>> ObterOSNaoIniciadas()
        {
            var os = await _context
                .OrdemsDeServicos
                .Include(i => i.Cliente)
                .Where(w => !w.DataInicio.HasValue)
                .OrderBy(o => o.DataCadastro)
                .ToListAsync();

            return os;
        }

        public async Task<IEnumerable<OrdemDeServico>> ObterOSIniciadas()
        {
            var os = await _context
                .OrdemsDeServicos
                .Include(i => i.Cliente)
                .Include(i => i.Responsavel)
                .Include(i => i.ServicosOS)
                    .ThenInclude(i => i.Servico)
                .Include(i => i.ProdutosOS)
                    .ThenInclude(i => i.Produto)
                .Where(w => w.DataInicio.HasValue && !w.DataFim.HasValue)
                .OrderBy(o => o.DataInicio)
                .ToListAsync();

            return os;
        }

        public async Task<IEnumerable<OrdemDeServico>> ObterOSFinalizadas()
        {
            var os = await _context
                .OrdemsDeServicos
                .Include(i => i.Cliente)
                .Include(i => i.Responsavel)
                .Include(i => i.ServicosOS)
                    .ThenInclude(i => i.Servico)
                .Include(i => i.ProdutosOS)
                    .ThenInclude(i => i.Produto)
                .Where(w => w.DataFim.HasValue)
                .OrderBy(o => o.DataFim)
                .ToListAsync();

            return os;
        }
    }

}
