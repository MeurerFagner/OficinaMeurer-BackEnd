using OficinaMeurer.Domain.Entidades;

namespace OficinaMeurer.Domain.Interfaces.Infra
{
    public interface IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity> Get(long id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
