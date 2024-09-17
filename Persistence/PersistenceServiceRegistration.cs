using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositorios;

namespace Infraestructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer<GalleryContext>(configuration.GetConnectionString("DefaultConnection"));
            services.AddScoped<IImageRepository, ImageRepository>();
            return services;
        }
    }
}
