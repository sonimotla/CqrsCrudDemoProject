using CqrsCrudDemo.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CqrsCrudDemo.Application.Interfaces;

namespace CqrsCrudDemo.Persistance
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistanceService(this IServiceCollection service,IConfiguration configuration) {
            //Register Entity framework service 
            service.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("CqrsCrudConnection")));
            service.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }
    }
}
