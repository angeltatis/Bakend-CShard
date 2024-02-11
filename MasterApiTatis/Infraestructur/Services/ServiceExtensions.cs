using MasterApiTatis.Application.Implemets;
using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Repository;

namespace MasterApiTatis.Infraestructur.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            //producto
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductImp>();

            //unidad
            services.AddScoped<IUnidadRepository, UnidadRepository>();
            services.AddScoped<IUnidadService, UnidadImp>();

            //detalle
            services.AddScoped<IUnidProductRepository, UnidProductRepository>();
            services.AddScoped<IUnidProductService, IUnidProductImp>();

            //deaprtamento
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IDepartamentoService, IDepartamentoImp>();

            //Grupo
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IGrupoService, IGrupoImp>();

            //SubGrupo
            services.AddScoped<ISubGrupoRepository, SubGrupoRepository>();
            services.AddScoped<ISubGrupoService, ISubGrupoImp>();
            //Tipo
            services.AddScoped<ITipoProductoRepository, TipoProductRepository>();
            services.AddScoped<ITipoProductService, ITipoProductImp>();

            //Serie ncf
            services.AddScoped<ISerieNcfRepository, SerieNcfRepository>();
            services.AddScoped<ISerieNcfService, ISerieNcfImp>();


            // Añade otros servicios y repositorios...
            return services;
        }
    }
}
