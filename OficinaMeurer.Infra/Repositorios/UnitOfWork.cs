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

        public UnitOfWork(Context context, IClienteRepositorio clienteRepositorio)
        {
            _context = context;
            Clientes = clienteRepositorio;
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
