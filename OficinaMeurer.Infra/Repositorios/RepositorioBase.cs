using Microsoft.EntityFrameworkCore;
using OficinaMeurer.Domain.Entidades;
using OficinaMeurer.Domain.Interfaces.Infra;

namespace OficinaMeurer.Infra.Repositorios
{
    public abstract class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        protected readonly Context _context;

        public RepositorioBase(Context context)
        {
            _context = context;
        }

        public async Task Delete(TEntity entity)
        {
            await Task.FromResult(_context.Set<TEntity>().Remove(entity));
        }

        public async Task Insert(TEntity entity)
        {
            entity.DataCadastro = DateTime.Now;
            await Task.FromResult(_context.Set<TEntity>().Add(entity));
        }

        public async Task Update(TEntity entity)
        {
            await Task.FromResult(_context.Set<TEntity>().Update(entity));
        }

        public async Task<TEntity> Get(long id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
