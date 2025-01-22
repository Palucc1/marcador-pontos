using Application.Application;
using Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interface;
using Repository.Repository;
using Service.Interface;
using Service.Service;

namespace IoC
{
    public static class DependencyResolver
    {
        public static void AddInjectionContainer(this IServiceCollection services)
        {
            AddApplicationContainer(services);
            AddServicesContainer(services);
            AddRepositoriesContainer(services);
        }

        private static void AddApplicationContainer(IServiceCollection services)
        {
            services.AddTransient<IPartidaApplication, PartidaApplication>();
        }

        private static void AddServicesContainer(IServiceCollection services)
        {
            services.AddTransient<IPartidaService, PartidaService>();
        }

        private static void AddRepositoriesContainer(IServiceCollection services)
        {
            services.AddTransient<IPartidaRepository, PartidaRepository>();
        }
    }
}
