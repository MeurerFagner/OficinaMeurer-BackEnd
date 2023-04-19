using OficinaMeurer.APP.Mapper;
using OficinaMeurer.APP.Services;
using OficinaMeurer.Domain.Interfaces.Aplication;
using OficinaMeurer.Domain.Interfaces.Infra;
using OficinaMeurer.Infra.Repositorios;

namespace OficinaMeurer.API.Configurations
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IOrdemDeServicoRepositorio, OrdemDeServicoRepositorio>();
        
            services.AddScoped<IClienteApp, ClienteApp>();
            services.AddScoped<IOrdemDeServicoApp, OrdemDeServicoApp>();

            services.AddAutoMapper(m => m.AddProfile(new MapperProfile()));
        }
    }
}
