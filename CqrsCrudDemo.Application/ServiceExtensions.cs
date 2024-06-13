using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CqrsCrudDemo.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureAppService(this IServiceCollection service) {
            service.AddMediatR(conf=>conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
