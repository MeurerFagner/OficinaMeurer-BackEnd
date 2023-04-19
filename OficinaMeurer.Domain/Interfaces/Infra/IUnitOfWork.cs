using OficinaMeurer.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaMeurer.Domain.Interfaces.Infra
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepositorio Clientes { get; }
        IOrdemDeServicoRepositorio OrdemDeServico { get; }

        Task Commit();
        Task<TEntity> Get<TEntity>(long id) where TEntity : EntidadeBase;
        Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : EntidadeBase;
    }

}
