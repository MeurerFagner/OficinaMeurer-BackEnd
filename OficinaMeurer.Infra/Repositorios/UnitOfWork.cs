using Microsoft.EntityFrameworkCore;
using OficinaMeurer.Domain.Entidades;
using OficinaMeurer.Domain.Interfaces.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaMeurer.Infra.Repositorios
{
    public class UnitOfWork : IUnitOfWork 
    {
        protected readonly Context _context;

        public IClienteRepositorio Clientes { get; }
        public IOrdemDeServicoRepositorio OrdemDeServico{ get; }

        public UnitOfWork(Context context, IClienteRepositorio clienteRepositorio, IOrdemDeServicoRepositorio ordemDeServico)
        {
            _context = context;
            Clientes = clienteRepositorio;
            OrdemDeServico = ordemDeServico;
        }

        public async Task<TEntity> Get<TEntity>(long id) where TEntity : EntidadeBase
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : EntidadeBase
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
