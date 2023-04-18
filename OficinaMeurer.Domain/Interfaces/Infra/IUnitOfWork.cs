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

        Task Commit();
    }

}
